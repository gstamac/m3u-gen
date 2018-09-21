namespace ID3Utils.Frames.Parsers
{
    class PublisherTextFrameParser : TextFrameParser
	{
		protected override Frame ParseFrame(byte[] data)
		{
			return new PublisherTextFrame(ParseTextFrame(data));
		}
	}
}

