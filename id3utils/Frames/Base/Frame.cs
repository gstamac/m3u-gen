namespace ID3Utils.Frames
{
    public abstract class Frame
	{
		//public abstract Parsers.FrameParser CreateParser(ID3v2MajorVersion version, string frameID);
		public abstract Writers.FrameWriter CreateWriter(ID3v2MajorVersion version, EncodingScheme encoding);
	}
}
