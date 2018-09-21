using ID3Utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace m3uGenerator
{
    public class M3uGenerator : IDisposable
    {
        private string root;
        private bool displayOnly;
        private string bakFolder;
        private List<string> undoCommands = new List<string>();
        private StreamWriter logFile = null;

        public M3uGenerator(string root, bool displayOnly)
        {
            this.root = root;
            this.displayOnly = displayOnly;
            bakFolder = Path.Combine(root, $"bak_{DateTime.Now:yyyy-MM-dd-HH-mm-ss}");
        }

        public void Run()
        {
            if (!displayOnly)
            {
                Directory.CreateDirectory(bakFolder);
                logFile = new StreamWriter(File.Create(Path.Combine(bakFolder, "generator.log")));
            }

            Scan(root);

            if (!displayOnly && undoCommands.Count > 0)
            {
                string undoFilename = Path.Combine(bakFolder, "undo.cmd");
                Log($"Writing {undoFilename}");
                undoCommands.Add($"del {undoFilename}");
                undoCommands.Add($"rd /s /q {bakFolder}");
                undoCommands.Add("");
                undoCommands.Add("pause");
                File.WriteAllLines(undoFilename, undoCommands);
            }
        }

        private void Scan(string folder)
        {
            Log("-------------------------------------------");
            Log($"Scanning {folder}");

            List<string> m3uContent = new List<string>();
            m3uContent.Add("#EXTM3U");

            foreach (Mp3Info mp3Info in GetFileList(folder))
            {
                Log($"\tFilename: {mp3Info.Filename}", false);
                Log($"\tSongName: {mp3Info.SongName}", false);
                Log($"\tTrackNumber: {mp3Info.TrackNumber}", false);
                Log($"\tDuration: {mp3Info.Duration}", false);

                if (!mp3Info.Filename.Equals(mp3Info.NewFilename))
                {
                    Log($"\tRenaming {mp3Info.Filename} to {mp3Info.NewFilename}");
                    if (!displayOnly)
                    {
                        string oldPath = Path.Combine(folder, mp3Info.Filename);
                        string newPath = Path.Combine(folder, mp3Info.NewFilename);
                        File.Move(oldPath, newPath);
                        undoCommands.Add($"ren \"{newPath}\" \"{mp3Info.Filename}\"");
                    }
                }
                m3uContent.Add($"#EXTINF:{mp3Info.Duration},{mp3Info.SongName}");
                m3uContent.Add(mp3Info.NewFilename);
            }
            if (m3uContent.Count > 1)
            {
                var m3uFilename = Path.ChangeExtension(Path.Combine(folder, Path.GetFileName(folder)), ".m3u");
                string bakFilename = Path.Combine(bakFolder, Path.GetFileName(m3uFilename));
                bool writeIt = true;
                bool backedIt = false;
                if (File.Exists(m3uFilename))
                {
                    string[] oldM3uContent = File.ReadAllLines(m3uFilename);
                    if (!string.Join("\n", oldM3uContent).Equals(string.Join("\n", m3uContent)))
                    {
                        Log($"\tBacking up {m3uFilename}");
                        if (!displayOnly)
                            File.Move(m3uFilename, bakFilename);
                        backedIt = true;
                    }
                    else
                    {
                        writeIt = false;
                    }
                }
                if (writeIt)
                {
                    Log($"Writing {m3uFilename}");
                    if (!displayOnly)
                    {
                        File.WriteAllLines(m3uFilename, m3uContent);
                        undoCommands.Add($"del \"{m3uFilename}\"");
                        if (backedIt)
                            undoCommands.Add($"ren \"{bakFilename}\" \"{Path.GetFileName(m3uFilename)}\"");
                    }
                }
            }

            ScanSubfolders(folder);
        }

        private void ScanSubfolders(string folder)
        {
            try
            {
                foreach (string subfolder in Directory.EnumerateDirectories(folder))
                {
                    Scan(subfolder);
                }
            }
            catch (Exception e)
            {
                Log("Error: " + e);
            }
        }

        private List<Mp3Info> GetFileList(string folder)
        {
            List<Mp3Info> list = new List<Mp3Info>();
            try
            {
                foreach (string filename in Directory.EnumerateFiles(folder, "*.mp3"))
                {
                    try
                    {
                        Log($"Found: {filename}", false);

                        var mp3Info = new Mp3Info
                        {
                            Filename = Path.GetFileName(filename),
                            NewFilename = NormalizeFilename(filename),
                            SongName = Path.GetFileNameWithoutExtension(filename).Replace('_', ' '),
                            TrackNumber = 0,
                            Duration = 0
                        };
                        try
                        {
                            SimpleTag simpleTag = SimpleTag.FromFile(filename);
                            if (simpleTag != null)
                            {
                                if (!string.IsNullOrWhiteSpace(simpleTag.Artist) && !string.IsNullOrWhiteSpace(simpleTag.Title))
                                    mp3Info.SongName = $"{simpleTag.Artist} - {simpleTag.Title}";
                                mp3Info.TrackNumber = simpleTag.TrackNumber;
                                mp3Info.Duration = simpleTag.Length / 1000;
                            }
                        }
                        catch (Exception e)
                        {
                            Log("Error: " + e);
                        }
                        list.Add(mp3Info);
                    }
                    catch (Exception e)
                    {
                        Log("Error: " + e);
                    }
                }
            }
            catch (Exception e)
            {
                Log("Error: " + e);
            }
            return list.OrderBy(f => f.TrackNumber).ThenBy(f => f.SongName).ToList();
        }

        private string NormalizeFilename(string filename)
        {
            return Regex.Replace(Path.GetFileName(filename), @"[^a-zA-Z0-9_&'\.\[\]\(\)\-]", "_");
            //return Path.GetFileName(filename).Replace(' ', '_');
        }

        private void Log(string text, bool toConsole = true)
        {
            if (logFile != null)
            {
                logFile.WriteLine(text);
                logFile.Flush();
            }
            if (toConsole)
                Console.WriteLine(text);
        }

        public void Dispose()
        {
            if (logFile != null)
            {
                logFile.Flush();
                logFile.Dispose();
                logFile = null;
            }
        }
    }
}
