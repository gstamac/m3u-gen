namespace ID3Utils.Frames.Parsers
{
    class OfficialAudioSourceUrlFrameParser : UrlFrameParser
	{
		protected override Frame ParseFrame(byte[] data)
		{
			return new OfficialAudioSourceUrlFrame(ParseUrlFrame(data));
		}
	}
}