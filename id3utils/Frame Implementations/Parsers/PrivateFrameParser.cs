using ID3Utils.Fields;

namespace ID3Utils.Frames.Parsers
{
    class PrivateFrameParser : FrameParser
	{
		protected override Frame ParseFrame(byte[] data)
		{
			int place=0;

			TextField ownerField=TextField.CreateTextField(true, EncodingScheme.Ascii);
			place+=ownerField.Parse(data, place);

			BinaryField dataField=new BinaryField();
			place+=dataField.Parse(data, place);

			return new PrivateFrame(ownerField.Text,dataField.Data);
		}
	}
}

