using System;

namespace ID3Utils.Frames
{

    public abstract class TextFrame :Frame
	{
		private string _text;

		public string Text
		{
			get
			{
				return _text;
			}
			set
			{
				if(value==null)
				{
					throw new ArgumentNullException("The set value can not be null.");
				}

				Validate(value);
				_text = value;
			}
		}

		public TextFrame(string text)
		{
			if(text==null)
			{
				throw new ArgumentNullException("The passed text parameter can not be null.");
			}
			Validate(text);
			this._text=text;
			Parse();
		}

		protected virtual void Validate(string value)
		{
		}

		protected virtual void Parse()
		{
		}
	}
}
