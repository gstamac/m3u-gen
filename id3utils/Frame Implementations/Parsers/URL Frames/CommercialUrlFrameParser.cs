namespace ID3Utils.Frames.Parsers
{
    class CommercialUrlFrameParser : UrlFrameParser
	{
		protected override Frame ParseFrame(byte[] data)
		{
			return new CommercialUrlFrame(ParseUrlFrame(data));
		}
	}
}