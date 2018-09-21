namespace ID3Utils.Frames.Parsers
{
    class PartOfSetTextFrameParser : TextFrameParser
	{
		protected override Frame ParseFrame(byte[] data)
		{
			return new PartOfSetTextFrame(ParseTextFrame(data));
		}
	}
}


