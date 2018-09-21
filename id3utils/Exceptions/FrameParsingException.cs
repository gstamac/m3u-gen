using System;

namespace ID3Utils
{
    /// <summary>
    /// FrameParsingException is thrown when an error is found while trying to parse a frame.
    /// </summary>
    public class FrameParsingException : NonFatalException
	{
		/// <summary>
		/// Creates a new instance of FrameParsingException.
		/// </summary>
		public FrameParsingException()
		{
		}
		/// <summary>
		/// Creates a new instance of FrameParsingException.
		/// </summary>
		/// <param name="message">The error message that explains the reason for the exception.</param>
		public FrameParsingException(string message)
			: base(message)
		{
		}
		/// <summary>
		/// Creates a new instance of FrameParsingException.
		/// </summary>
		/// <param name="message">The error message that explains the reason for the exception.</param>
		/// <param name="inner">The exception that is the cause of the current exception, or a null reference (Nothing in Visual Basic) if no inner exception is specified.</param>
		public FrameParsingException(string message, Exception inner)
			: base(message, inner)
		{
		}
	}
}
