using ID3Utils.Fields;

namespace ID3Utils.Frames.Parsers
{
    class PlayCounterFrameParser : FrameParser
	{
		protected override Frame ParseFrame(byte[] data)
		{
			int place=0;

			BinaryField dataField=new BinaryField();
			place+=dataField.Parse(data, place);

			if(dataField.Data.Length!=4)
			{
				throw new FrameParsingException("Length of a Play Counter frame should be exactly 4. Larger frames are not yet supported.");
			}

			int counter=
				(((int)dataField.Data[0]) << 24) + 
				(((int)dataField.Data[1]) << 16) + 
				(((int)dataField.Data[2]) << 8) + 
				((int)dataField.Data[3]);
			return new PlayCounterFrame(counter);
		}
	}
}

