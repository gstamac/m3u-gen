namespace ID3Utils.Frames.Parsers
{
    class InitialKeyTextFrameParser : TextFrameParser
	{
		protected override Frame ParseFrame(byte[] data)
		{
			return new InitialKeyTextFrame(ParseTextFrame(data));
		}
	}
}