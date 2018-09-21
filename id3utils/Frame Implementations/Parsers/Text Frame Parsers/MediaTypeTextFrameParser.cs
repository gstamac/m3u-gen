namespace ID3Utils.Frames.Parsers
{
    class MediaTypeTextFrameParser : TextFrameParser
	{
		protected override Frame ParseFrame(byte[] data)
		{
			return new MediaTypeTextFrame(ParseTextFrame(data));
		}
	}
}


