using System;

namespace ID3Utils
{
    /// <summary>
    /// InvalidFrameValueException is thrown when an invalid value is specified for a 
    /// given frame. For example, a value longer than 4 characters for the Year frame.
    /// </summary>
    public class InvalidFrameValueException : NonFatalException
	{
		private string _invalidValue;

		/// <summary>
		/// Gets the rejected string value.
		/// </summary>
		public string InvalidValue
		{
			get
			{
				return _invalidValue;
			}
		}

		/// <summary>
		/// Initializes a new instance of InvalidFrameValueException.
		/// </summary>
		/// <param name="invalidValue">The rejected string value.</param>
		public InvalidFrameValueException(string invalidValue)
		{
			this._invalidValue=invalidValue;
		}
		/// <summary>
		/// Initializes a new instance of InvalidFrameValueException.
		/// </summary>
		/// <param name="invalidValue">The rejected string value.</param>
		/// <param name="message">The error message that explains the reason for the exception.</param>
		public InvalidFrameValueException(string invalidValue,string message) : base(message)
		{
			this._invalidValue=invalidValue;
		}
		/// <summary>
		/// Initializes a new instance of InvalidFrameValueException.
		/// </summary>
		/// <param name="invalidValue">The rejected string value.</param>
		/// <param name="message">The error message that explains the reason for the exception.</param>
		/// <param name="inner"></param>
		public InvalidFrameValueException(string invalidValue, string message, Exception inner)
			: base(message, inner)
		{
			this._invalidValue=invalidValue;
		}
	}
}
