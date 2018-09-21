namespace ID3Utils.Frames.Parsers
{
    class BeatsPerMinuteTextFrameParser : TextFrameParser
	{
		protected override Frame ParseFrame(byte[] data)
		{
			return new BeatsPerMinuteTextFrame(ParseTextFrame(data));
		}
	}
}

