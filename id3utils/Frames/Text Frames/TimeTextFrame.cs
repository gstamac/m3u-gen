namespace ID3Utils.Frames
{

    public class TimeTextFrame : TextFrame
	{
		public TimeTextFrame(string text)
			: base(text)
		{
		}

		protected override void Validate(string value)
		{
			if(value.Length>4)
			{
				throw new InvalidFrameValueException(value, "Invalid value specified for Time frame. Maximum length is 4.");
			}
		}

		public static ID3Utils.Frames.Parsers.FrameParser CreateParser(ID3v2MajorVersion version, string frameID)
		{
			if(version==ID3v2MajorVersion.Version2 && frameID=="TIM")
			{
				return new Parsers.TimeTextFrameParser();
			}
			if(version==ID3v2MajorVersion.Version3 && frameID=="TIME")
			{
				return new Parsers.TimeTextFrameParser();
			}
			return null;
		}

		public override ID3Utils.Frames.Writers.FrameWriter CreateWriter(ID3v2MajorVersion version, EncodingScheme encoding)
		{
			if(version==ID3v2MajorVersion.Version2)
			{
				return new Writers.TextFrameWriter(this, "TIM", Writers.FrameHeaderWriter.CreateFrameHeaderWriter(version), encoding);
			}
			if(version==ID3v2MajorVersion.Version3)
			{
				return new Writers.TextFrameWriter(this, "TIME", Writers.FrameHeaderWriter.CreateFrameHeaderWriter(version), encoding);
			}
			return null;
		}
	}
}