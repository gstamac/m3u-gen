namespace ID3Utils.Frames.Parsers
{
    class OriginalAlbumTextFrameParser : TextFrameParser
	{
		protected override Frame ParseFrame(byte[] data)
		{
			return new OriginalAlbumTextFrame(ParseTextFrame(data));
		}
	}
}


