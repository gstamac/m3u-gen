namespace ID3Utils.Frames.Parsers
{
    class TaggingTimeTextFrameParser : TextFrameParser
	{
		protected override Frame ParseFrame(byte[] data)
		{
			return new TaggingTimeTextFrame(ParseTextFrame(data));
		}
	}
}