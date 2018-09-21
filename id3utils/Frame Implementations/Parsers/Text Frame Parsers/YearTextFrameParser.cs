namespace ID3Utils.Frames.Parsers
{
    class YearTextFrameParser : TextFrameParser
	{
		protected override Frame ParseFrame(byte[] data)
		{
			return new YearTextFrame(ParseTextFrame(data));
		}
	}
}


