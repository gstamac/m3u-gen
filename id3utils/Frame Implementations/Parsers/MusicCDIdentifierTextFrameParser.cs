using ID3Utils.Fields;

namespace ID3Utils.Frames.Parsers
{
    class MusicCDIdentifierFrameParser : FrameParser
	{
		protected override Frame ParseFrame(byte[] data)
		{
			int place=0;

			BinaryField dataField=new BinaryField();
			place+=dataField.Parse(data, place);

			return new MusicCDIdentifierFrame(dataField.Data);
		}
	}
}

