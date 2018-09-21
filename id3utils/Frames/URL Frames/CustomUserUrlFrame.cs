namespace ID3Utils.Frames
{

    public class CustomUserUrlFrame : UrlFrame
	{
		public CustomUserUrlFrame(string url)
			: base(url)
		{
		}

		public static ID3Utils.Frames.Parsers.FrameParser CreateParser(ID3v2MajorVersion version, string frameID)
		{
			if(version==ID3v2MajorVersion.Version2 && frameID=="WXX")
			{
				return new Parsers.CustomUserUrlFrameParser();
			}
			if((version==ID3v2MajorVersion.Version3 || version==ID3v2MajorVersion.Version4) && frameID=="WXXX")
			{
				return new Parsers.CustomUserUrlFrameParser();
			}
			return null;
		}

		public override ID3Utils.Frames.Writers.FrameWriter CreateWriter(ID3v2MajorVersion version, EncodingScheme encoding)
		{
			if(version==ID3v2MajorVersion.Version2)
			{
				return new Writers.UrlFrameWriter(this, "WXX", Writers.FrameHeaderWriter.CreateFrameHeaderWriter(version), encoding);
			}
			if(version==ID3v2MajorVersion.Version3 || version==ID3v2MajorVersion.Version4)
			{
				return new Writers.UrlFrameWriter(this, "WXXX", Writers.FrameHeaderWriter.CreateFrameHeaderWriter(version), encoding);
			}
			return null;
		}
	}
}