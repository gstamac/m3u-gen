namespace ID3Utils.Frames.Parsers
{
    class CustomUserTextFrameParser : TextFrameParser
	{
		protected override Frame ParseFrame(byte[] data)
		{
			return new CustomUserTextFrame(ParseTextFrame(data));
		}
	}
}