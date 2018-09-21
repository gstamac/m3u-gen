namespace ID3Utils.Frames
{
    public class LyricsExtendedTextFrame : ExtendedTextFrame
	{
		public LyricsExtendedTextFrame(string text, string description, LanguageCode language)
			: base(text, description, language)
		{
		}

		public static ID3Utils.Frames.Parsers.FrameParser CreateParser(ID3v2MajorVersion version, string frameID)
		{
			if(version==ID3v2MajorVersion.Version2 && frameID=="ULT")
			{
				return new Parsers.LyricsExtendedTextFrameParser();
			}
			if((version==ID3v2MajorVersion.Version3 || version==ID3v2MajorVersion.Version4) && frameID=="USLT")
			{
				return new Parsers.LyricsExtendedTextFrameParser();
			}
			return null;
		}

		public override ID3Utils.Frames.Writers.FrameWriter CreateWriter(ID3v2MajorVersion version, EncodingScheme encoding)
		{
			if(version==ID3v2MajorVersion.Version2)
			{
				return new Writers.ExtendedTextFrameWriter(this, "ULT", Writers.FrameHeaderWriter.CreateFrameHeaderWriter(version), encoding);
			}
			if(version==ID3v2MajorVersion.Version3 || version==ID3v2MajorVersion.Version4)
			{
				return new Writers.ExtendedTextFrameWriter(this, "USLT", Writers.FrameHeaderWriter.CreateFrameHeaderWriter(version), encoding);
			}
			return null;
		}
	}
}
