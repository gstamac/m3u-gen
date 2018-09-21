namespace ID3Utils.Frames.Parsers
{
    class FileTypeTextFrameParser : TextFrameParser
	{
		protected override Frame ParseFrame(byte[] data)
		{
			return new FileTypeTextFrame(ParseTextFrame(data));
		}
	}
}

