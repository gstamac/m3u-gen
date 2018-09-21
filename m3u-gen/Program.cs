using System;
using System.IO;
using System.Linq;
using System.Text;

namespace m3uGenerator
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Usage: m3u-gen [root-folder]");

            string root = Directory.GetCurrentDirectory();
            if (args.Length > 0)
            {
                root = Path.GetFullPath(args[0]);
            }

            using (M3uGenerator m3UGenerator = new M3uGenerator(root, false))
            {
                m3UGenerator.Run();
            }

            Console.WriteLine("Finished!");
            Console.ReadKey();
        }
    }
}
