namespace ID3Utils.Frames.Parsers
{
    class AlbumTextFrameParser : TextFrameParser
	{
		protected override Frame ParseFrame(byte[] data)
		{
			return new AlbumTextFrame(ParseTextFrame(data));
		}
	}
}


