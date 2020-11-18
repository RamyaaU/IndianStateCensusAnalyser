using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace IndianStateCensusAnalyser
{
    public class CensusAnalyserException : Exception
    {
        public enum ExceptionType
        {
            FILE_NOT_FOUND, INVALID_FILE_TYPE,
            INCORRECT_DELIMITER, INCORRECT_HEADER, NO_SUCH_COUNTRY
        }

        /// <summary>
        /// The exception type
        /// </summary>
        public ExceptionType eType;

        /// <summary>
        /// constructor for the base message from the exception class.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="exceptionType">Type of the exception.</param>
        public CensusAnalyserException(string message, ExceptionType exceptionType) : base(message)
        {
            this.eType = exceptionType;
        }
    }
}
