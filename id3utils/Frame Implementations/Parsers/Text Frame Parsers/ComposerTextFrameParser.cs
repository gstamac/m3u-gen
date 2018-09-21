namespace ID3Utils.Frames.Parsers
{
    class ComposerTextFrameParser : TextFrameParser
	{
		protected override Frame ParseFrame(byte[] data)
		{
			return new ComposerTextFrame(ParseTextFrame(data));
		}
	}
}