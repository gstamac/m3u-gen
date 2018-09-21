namespace ID3Utils.Frames.Parsers
{
    class OriginalArtistTextFrameParser : TextFrameParser
	{
		protected override Frame ParseFrame(byte[] data)
		{
			return new OriginalArtistTextFrame(ParseTextFrame(data));
		}
	}
}


