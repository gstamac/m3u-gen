namespace ID3Utils.Frames.Parsers
{
    class TimeTextFrameParser : TextFrameParser
	{
		protected override Frame ParseFrame(byte[] data)
		{
			return new TimeTextFrame(ParseTextFrame(data));
		}
	}
}