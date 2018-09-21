namespace ID3Utils.Frames.Parsers
{
    class LanguageTextFrameParser : TextFrameParser
	{
		protected override Frame ParseFrame(byte[] data)
		{
			return new LanguageTextFrame(ParseTextFrame(data));
		}
	}
}