namespace ID3Utils.Fields
{
    public class SingleByteField :Field
	{
		private byte _value;

		public byte Value
		{
			get
			{
				return _value;
			}
			set
			{
				_value = value;
			}
		}

		public SingleByteField()
			: base()
		{

		}

		public SingleByteField(byte value)
			:base()
		{
			this.Value=value;
		}

		public override void WriteToStream(System.IO.Stream stream)
		{
			base.WriteToStream(stream);
			stream.WriteByte(this._value);
		}

		public override int Parse(byte[] data, int offset)
		{
			int read = base.Parse(data, offset);
			_value=data[offset];
			return read+1;
		}

		public override int Length
		{
			get
			{
				return 1;
			}
		}
	}
}

