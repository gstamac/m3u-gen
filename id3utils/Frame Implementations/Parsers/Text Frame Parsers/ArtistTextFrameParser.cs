namespace ID3Utils.Frames.Parsers
{
    class ArtistTextFrameParser : TextFrameParser
	{
		protected override Frame ParseFrame(byte[] data)
		{
			return new ArtistTextFrame(ParseTextFrame(data));
		}
	}
}
