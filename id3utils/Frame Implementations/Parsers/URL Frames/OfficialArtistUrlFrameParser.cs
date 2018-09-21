namespace ID3Utils.Frames.Parsers
{
    class OfficialArtistUrlFrameParser : UrlFrameParser
	{
		protected override Frame ParseFrame(byte[] data)
		{
			return new OfficialArtistUrlFrame(ParseUrlFrame(data));
		}
	}
}