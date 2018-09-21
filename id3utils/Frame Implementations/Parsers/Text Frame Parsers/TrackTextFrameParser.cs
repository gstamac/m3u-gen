namespace ID3Utils.Frames.Parsers
{
    class TrackTextFrameParser : TextFrameParser
	{
		protected override Frame ParseFrame(byte[] data)
		{
			return new TrackTextFrame(ParseTextFrame(data));
		}
	}
}


