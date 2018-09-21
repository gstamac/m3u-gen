namespace ID3Utils.Frames.Parsers
{
    class GenreTextFrameParser : TextFrameParser
	{
		protected override Frame ParseFrame(byte[] data)
		{
			return new GenreTextFrame(ParseTextFrame(data));
		}
	}
}


