namespace ID3Utils.Frames.Parsers
{
    class CommentExtendedTextFrameParser : ExtendedTextFrameParser
	{
		protected override Frame ParseFrame(byte[] data)
		{
			string text, description;
			LanguageCode lang;
			text=ParseExtendedTextFrame(data, out  description, out lang);
			return new CommentExtendedTextFrame(text, description, lang);
		}
	}
}


