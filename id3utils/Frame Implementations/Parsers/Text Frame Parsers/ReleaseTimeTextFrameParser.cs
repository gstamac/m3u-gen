namespace ID3Utils.Frames.Parsers
{
    class ReleaseTimeTextFrameParser : TextFrameParser
	{
		protected override Frame ParseFrame(byte[] data)
		{
			return new ReleaseTimeTextFrame(ParseTextFrame(data));
		}
	}
}