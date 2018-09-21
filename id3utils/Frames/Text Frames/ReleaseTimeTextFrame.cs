namespace ID3Utils.Frames
{

    public class ReleaseTimeTextFrame : TextFrame
	{
		public ReleaseTimeTextFrame(string text)
			: base(text)
		{
		}

		public static ID3Utils.Frames.Parsers.FrameParser CreateParser(ID3v2MajorVersion version, string frameID)
		{
			if(version==ID3v2MajorVersion.Version4 && frameID=="TDRL")
			{
				return new Parsers.ReleaseTimeTextFrameParser();
			}
			return null;
		}

		public override ID3Utils.Frames.Writers.FrameWriter CreateWriter(ID3v2MajorVersion version, EncodingScheme encoding)
		{
			if(version==ID3v2MajorVersion.Version4)
			{
				return new Writers.TextFrameWriter(this, "TDRL", Writers.FrameHeaderWriter.CreateFrameHeaderWriter(version), encoding);
			}
			return null;
		}
	}
}