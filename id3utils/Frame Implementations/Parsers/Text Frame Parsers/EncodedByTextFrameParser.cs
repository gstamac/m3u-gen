namespace ID3Utils.Frames.Parsers
{
    class EncodedByTextFrameParser : TextFrameParser
	{
		protected override Frame ParseFrame(byte[] data)
		{
			return new EncodedByTextFrame(ParseTextFrame(data));
		}
	}
}


