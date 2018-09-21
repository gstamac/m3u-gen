namespace ID3Utils.Frames.Parsers
{
    class OrchestraTextFrameParser : TextFrameParser
	{
		protected override Frame ParseFrame(byte[] data)
		{
			return new OrchestraTextFrame(ParseTextFrame(data));
		}
	}
}

