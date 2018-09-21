namespace ID3Utils.Frames.Parsers
{
    class GroupingTextFrameParser : TextFrameParser
	{
		protected override Frame ParseFrame(byte[] data)
		{
			return new GroupingTextFrame(ParseTextFrame(data));
		}
	}
}


