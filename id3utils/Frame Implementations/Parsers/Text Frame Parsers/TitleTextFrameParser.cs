namespace ID3Utils.Frames.Parsers
{
    class TitleTextFrameParser : TextFrameParser
	{
		protected override Frame ParseFrame(byte[] data)
		{
			return new TitleTextFrame(ParseTextFrame(data));
		}
	}
}


