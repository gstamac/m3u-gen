namespace ID3Utils.Frames.Parsers
{
    class DateTextFrameParser : TextFrameParser
	{
		protected override Frame ParseFrame(byte[] data)
		{
			return new DateTextFrame(ParseTextFrame(data));
		}
	}
}