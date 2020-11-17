using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace IndianStateCensusAnalyser
{
    public class CheckFileExceptions
    {
        /// <summary>
        /// Checks the exceptions.
        /// </summary>
        /// <param name="csvPath">The CSV path.</param>
        /// <exception cref="IndianStateCensusAnalyser.CensusAnalyserException">
        /// File Does Not Exist
        /// or
        /// File Path is Improper
        /// </exception>
        public static void CheckExceptions(string csvPath)
        {
            if (File.Exists(csvPath) == false)
            {
                throw new CensusAnalyserException("File Does Not Exist", CensusAnalyserException.ExceptionType.FILE_NOT_FOUND);
            }
            if (Path.GetExtension(csvPath) != ".csv")
            {
                throw new CensusAnalyserException("File Path is Improper", CensusAnalyserException.ExceptionType.INVALID_FILE_TYPE);
            }

        }
    }
}