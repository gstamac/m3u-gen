using System;

namespace ID3Utils
{
    /// <summary>
    /// FeatureNotSupportedException is thrown when an ID3 feature that is not 
    /// supported in this implementation are encountered. Examples are Unsynchronization and
    /// Compression.
    /// </summary>
    public class FeatureNotSupportedException : NonFatalException
	{
		/// <summary>
		/// Creates a new instance of FeatureNotSupportedException.
		/// </summary>
		public FeatureNotSupportedException()
		{
		}
		/// <summary>
		/// Creates a new instance of FeatureNotSupportedException.
		/// </summary>
		/// <param name="message">The error message that explains the reason for the exception.</param>
		public FeatureNotSupportedException(string message)
			: base(message)
		{
		}
		/// <summary>
		/// Creates a new instance of FeatureNotSupportedException.
		/// </summary>
		/// <param name="message">The error message that explains the reason for the exception.</param>
		/// <param name="inner">The exception that is the cause of the current exception, or a null reference (Nothing in Visual Basic) if no inner exception is specified.</param>
		public FeatureNotSupportedException(string message, Exception inner)
			: base(message, inner)
		{
		}
	}
}
