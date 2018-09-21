namespace ID3Utils
{
    public class SimpleTag
    {

        public string Title { get; set; } = "";

        public string Artist { get; set; } = "";

        public string Album { get; set; } = "";

        public string Comment { get; set; } = "";

        public string Lyrics { get; set; } = "";

        public string EncodedBy { get; set; } = "";

        public string Copyright { get; set; } = "";

        public string Genre { get; set; } = "";

        public string Year { get; set; } = "";

        public int TrackNumber { get; set; }

        public int TotalTracks { get; set; }

        public int PartNumber { get; set; }

        public int TotalParts { get; set; }

        public string OriginalArtist { get; set; } = "";

        public string Composer { get; set; } = "";

        public string UserUrl { get; set; } = "";

        public string ArtistUrl { get; set; } = "";

        public string Grouping { get; set; } = "";

        public int BPM { get; set; }

        public int Length { get; set; }

        public static SimpleTag FromFile(string fileName)
        {
            SimpleTag result=new SimpleTag();
            TagBase tag=new TagBase();
            tag.ReadFromFile(fileName, new ID3Utils.Frames.Parsers.FrameParserFactory());
            foreach(Frames.Frame frame in tag.Frames)
            {
                if (frame is Frames.ArtistTextFrame)
                    result.Artist=((Frames.ArtistTextFrame)frame).Text;
                else if(frame is Frames.AlbumTextFrame)
                    result.Album=((Frames.AlbumTextFrame)frame).Text;
                else if(frame is Frames.CommentExtendedTextFrame)
                    result.Comment=((Frames.CommentExtendedTextFrame)frame).Text;
                else if(frame is Frames.ComposerTextFrame)
                    result.Composer=((Frames.ComposerTextFrame)frame).Text;
                else if(frame is Frames.CopyrightTextFrame)
                    result.Copyright=((Frames.CopyrightTextFrame)frame).Text;
                else if(frame is Frames.EncodedByTextFrame)
                    result.EncodedBy=((Frames.EncodedByTextFrame)frame).Text;
                else if(frame is Frames.GenreTextFrame)
                {
                    StandardGenreManager manager=new StandardGenreManager();
                    result.Genre=manager.TranslateToUserFriendly(((Frames.GenreTextFrame)frame).Text);
                }
                else if(frame is Frames.GroupingTextFrame)
                    result.Grouping=((Frames.GroupingTextFrame)frame).Text;
                else if(frame is Frames.LyricsExtendedTextFrame)
                    result.Lyrics=((Frames.LyricsExtendedTextFrame)frame).Text;
                else if(frame is Frames.OriginalArtistTextFrame)
                    result.OriginalArtist=((Frames.OriginalArtistTextFrame)frame).Text;
                else if(frame is Frames.TitleTextFrame)
                    result.Title=((Frames.TitleTextFrame)frame).Text;
                else if(frame is Frames.CustomUserUrlFrame)
                    result.UserUrl=((Frames.CustomUserUrlFrame)frame).Url;
                else if(frame is Frames.OfficialArtistUrlFrame)
                    result.ArtistUrl=((Frames.OfficialArtistUrlFrame)frame).Url;
                else if(frame is Frames.TrackTextFrame)
                {
                    result.TrackNumber=((Frames.TrackTextFrame)frame).TrackNumber;
                    result.TotalTracks=((Frames.TrackTextFrame)frame).TotalTracks;
                }
                else if(frame is Frames.PartOfSetTextFrame)
                {
                    result.PartNumber=((Frames.PartOfSetTextFrame)frame).PartNumber;
                    result.TotalParts=((Frames.PartOfSetTextFrame)frame).TotalParts;
                }
                else if(frame is Frames.YearTextFrame)
                {
                    string year=((Frames.YearTextFrame)frame).Text;
                    if(year!="")
                        result.Year=year.Substring(0, 4);
                }
                else if(frame is Frames.ReleaseTimeTextFrame)
                {
                    string year=((Frames.ReleaseTimeTextFrame)frame).Text;
                    if(year!="")
                        result.Year=year.Substring(0, 4);
                }
                else if (frame is Frames.BeatsPerMinuteTextFrame)
                {
                    result.BPM = int.Parse((((Frames.BeatsPerMinuteTextFrame)frame).Text));
                }
                else if (frame is Frames.LengthTextFrame)
                {
                    result.Length = int.Parse((((Frames.LengthTextFrame)frame).Text));
                }
            }

            return result;
        }

        //public void WriteToFile(string fileName)
        //{
        //	TagBase tag=new TagBase();
        //	if(this.Artist!="")			
        //		tag.Frames.Add(new Frames.ArtistTextFrame(this.Artist));			
        //	if(this.Album!="")
        //		tag.Frames.Add(new Frames.AlbumTextFrame(this.Album));
        //	if(this.ArtistUrl!="")
        //		tag.Frames.Add(new Frames.OfficialArtistUrlFrame(this.ArtistUrl));
        //	if(this.Comment!="")
        //		tag.Frames.Add(new Frames.CommentExtendedTextFrame(this.Comment,"", LanguageCode.eng));
        //	if(this.Composer!="")
        //		tag.Frames.Add(new Frames.ComposerTextFrame(this.Composer));
        //	if(this.Copyright!="")
        //		tag.Frames.Add(new Frames.CopyrightTextFrame(this.Copyright));
        //	if(this.EncodedBy!="")
        //		tag.Frames.Add(new Frames.EncodedByTextFrame(this.EncodedBy));
        //	if(this.Genre!="")
        //		tag.Frames.Add(new Frames.GenreTextFrame(this.Genre));
        //	if(this.Grouping!="")
        //		tag.Frames.Add(new Frames.GroupingTextFrame(this.Grouping));
        //	if(this.Lyrics!="")
        //		tag.Frames.Add(new Frames.LyricsExtendedTextFrame(this.Lyrics,"",LanguageCode.eng));
        //	if(this.OriginalArtist!="")
        //		tag.Frames.Add(new Frames.OriginalArtistTextFrame(this.OriginalArtist));
        //	if(this.Year!=null)
        //		tag.Frames.Add(new Frames.YearTextFrame(this.Year));
        //	if(this.Title!="")
        //		tag.Frames.Add(new Frames.TitleTextFrame(this.Title));
        //	if(this.UserUrl!="")
        //		tag.Frames.Add(new Frames.CustomUserTextFrame(this.UserUrl));
        //	if(this.OriginalArtist!="")
        //		tag.Frames.Add(new Frames.OriginalArtistTextFrame(this.OriginalArtist));
        //	
        //	if(this.BPM>0)
        //		tag.Frames.Add(new Frames.BeatsPerMinuteTextFrame(this.BPM));

        //	if(this.TrackNumber>0 && this.TotalTracks>0)
        //		tag.Frames.Add(new Frames.TrackTextFrame(this.TrackNumber,this.TotalTracks));
        //	else if(this.TrackNumber>0)
        //		tag.Frames.Add(new Frames.TrackTextFrame(this.TrackNumber));

        //	if(this.PartNumber>0 && this.TotalParts>0)
        //		tag.Frames.Add(new Frames.PartOfSetTextFrame(this.PartNumber, this.TotalParts));
        //	else if(this.PartNumber>0)
        //		tag.Frames.Add(new Frames.PartOfSetTextFrame(this.PartNumber));

        //	tag.WriteToFile(fileName, ID3v2MajorVersion.Version3, EncodingScheme.UnicodeWithBOM);
        //}
    }
}