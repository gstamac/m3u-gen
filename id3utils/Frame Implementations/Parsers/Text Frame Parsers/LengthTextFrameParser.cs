namespace ID3Utils.Frames.Parsers
{
    class LengthTextFrameParser : TextFrameParser
	{
		protected override Frame ParseFrame(byte[] data)
		{
			return new LengthTextFrame(ParseTextFrame(data));
		}
	}
}


