namespace ID3Utils.Frames.Parsers
{
    class SoftwareSettingsTextFrameParser : TextFrameParser
	{
		protected override Frame ParseFrame(byte[] data)
		{
			return new SoftwareSettingsTextFrame(ParseTextFrame(data));
		}
	}
}

