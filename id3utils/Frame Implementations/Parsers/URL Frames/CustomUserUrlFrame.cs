namespace ID3Utils.Frames.Parsers
{
    class CustomUserUrlFrameParser : UrlFrameParser
	{
		protected override Frame ParseFrame(byte[] data)
		{
			return new CustomUserUrlFrame(ParseUrlFrame(data));
		}
	}
}