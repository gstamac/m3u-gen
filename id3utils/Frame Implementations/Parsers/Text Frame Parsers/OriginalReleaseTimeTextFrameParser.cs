namespace ID3Utils.Frames.Parsers
{
    class OriginalReleaseTimeTextFrameParser : TextFrameParser
	{
		protected override Frame ParseFrame(byte[] data)
		{
			return new OriginalReleaseTimeTextFrame(ParseTextFrame(data));
		}
	}
}