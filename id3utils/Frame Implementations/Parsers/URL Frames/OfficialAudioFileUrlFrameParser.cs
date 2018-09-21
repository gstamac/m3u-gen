namespace ID3Utils.Frames.Parsers
{
    class OfficialAudioFileUrlFrameParser : UrlFrameParser
	{
		protected override Frame ParseFrame(byte[] data)
		{
			return new OfficialAudioFileUrlFrame(ParseUrlFrame(data));
		}
	}
}