using System;

namespace ID3Utils
{
    /// <summary>
    /// A FatalException is thrown if an unrecoverable error is encountered
    /// while reading or writing an ID3 tag.
    /// </summary>
    public class FatalException : Exception
	{
		/// <summary>
		/// Creates a new instance of FatalException.
		/// </summary>
		public FatalException()
		{
		}
		/// <summary>
		/// Creates a new instance of FatalException.
		/// </summary>
		/// <param name="message">The error message that explains the reason for the exception.</param>
		public FatalException(string message) : base(message)
		{
		}
		/// <summary>
		/// Creates a new instance of FatalException.
		/// </summary>
		/// <param name="message">The error message that explains the reason for the exception.</param>
		/// <param name="inner">The exception that is the cause of the current exception, or a null reference (Nothing in Visual Basic) if no inner exception is specified.</param>
		public FatalException(string message, Exception inner) : base(message, inner)
		{
		}
	}
}
