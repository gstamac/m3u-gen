using System;

namespace ID3Utils
{
    /// <summary>
    /// This exception is thrown when a corrupt or unrecognized field format
    /// is encountered.
    /// </summary>
    public class FieldParsingException : NonFatalException
	{
		private Type _fieldType;

		/// <summary>
		/// The type of the field that throwed the exception.
		/// </summary>
		public Type FieldType
		{
			get
			{
				return _fieldType;
			}
		}

		/// <summary>
		/// Creates a new instance of FieldParsingException.
		/// </summary>
		public FieldParsingException()
		{			
		}

		/// <summary>
		/// Initializes a new instance of FieldParsingException.
		/// </summary>
		/// <param name="fieldType">The type of the field that throwed the exception.</param>
		public FieldParsingException(Type fieldType)
		{
			this._fieldType=fieldType;
		}

		/// <summary>
		/// Initializes a new instance of FieldParsingException.
		/// </summary>
		/// <param name="fieldType">The type of the field that throwed the exception.</param>
		/// <param name="message">The error message that explains the reason for the exception.</param>
		public FieldParsingException(Type fieldType, string message) : base(message)
		{
			this._fieldType=fieldType;
		}

		/// <summary>
		/// Initializes a new instance of FieldParsingException.
		/// </summary>
		/// <param name="fieldType">The type of the field that throwed the exception.</param>		
		/// <param name="message">The error message that explains the reason for the exception.</param>
		/// <param name="inner">The exception that is the cause of the current exception, or a null reference (Nothing in Visual Basic) if no inner exception is specified.</param>
		public FieldParsingException(Type fieldType, string message, Exception inner) : base(message, inner)
		{
			this._fieldType=fieldType;
		}
	}
}

