namespace ID3Utils.Frames.Parsers
{
    class RecordingTimeTextFrameParser : TextFrameParser
	{
		protected override Frame ParseFrame(byte[] data)
		{
			return new RecordingTimeTextFrame(ParseTextFrame(data));
		}
	}
}

