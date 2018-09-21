namespace ID3Utils.Frames.Parsers
{
    class OriginalReleaseYearTextFrameParser : TextFrameParser
	{
		protected override Frame ParseFrame(byte[] data)
		{
			return new OriginalReleaseYearTextFrame(ParseTextFrame(data));
		}
	}
}