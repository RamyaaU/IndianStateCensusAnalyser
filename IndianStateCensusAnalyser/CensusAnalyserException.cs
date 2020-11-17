using System;
using System.Collections.Generic;
using System.Text;

namespace IndianStateCensusAnalyser
{
    public class CensusAnalyserException : Exception
    {
        /// <summary>
        /// enum variables declaration
        /// </summary>
        public enum ExceptionType
        {
            FILE_NOT_FOUND,
            INVALID_FILE_TYPE,
            INCORRECT_DELIMITER,
            INCORRECT_HEADER,
            NO_SUCH_COUNTRY
        }

        /// <summary>
        /// The exception type
        /// </summary>
        public ExceptionType eType;

        /// <summary>
        /// Initializes a new instance of the <see cref="CensusAnalyserException"/> class.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="exceptionType">Type of the exception.</param>
        public CensusAnalyserException(string message, ExceptionType exceptionType) : base(message)
        {
            this.eType = exceptionType;
        }
    }
}