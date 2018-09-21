namespace ID3Utils.Frames.Parsers
{
    class CopyrightTextFrameParser : TextFrameParser
	{
		protected override Frame ParseFrame(byte[] data)
		{
			return new CopyrightTextFrame(ParseTextFrame(data));
		}
	}
}


