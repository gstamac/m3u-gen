namespace ID3Utils.Frames.Parsers
{
    class EncodingTimeTextFrameParser : TextFrameParser
	{
		protected override Frame ParseFrame(byte[] data)
		{
			return new EncodingTimeTextFrame(ParseTextFrame(data));
		}
	}
}