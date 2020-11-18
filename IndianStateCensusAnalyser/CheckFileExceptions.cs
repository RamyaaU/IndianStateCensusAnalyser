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
        /// <param name="country">The country.</param>
        /// <exception cref="CSVAdapterFactory">
        /// File Does Not Exist
        /// or
        /// File Path is Improper
        /// or
        /// No such country
        /// </exception>
        public static void CheckExceptions(string csvPath, StateCensusAnalyser.Country country)
        {
            if (File.Exists(csvPath) == false)
            {
                throw new CSVAdapterFactory("File Does Not Exist", CSVAdapterFactory.ExceptionType.FILE_NOT_FOUND);
            }
            if (Path.GetExtension(csvPath) != ".csv")
            {
                throw new CSVAdapterFactory("File Path is Improper", CSVAdapterFactory.ExceptionType.INVALID_FILE_TYPE);
            }
            if (country != StateCensusAnalyser.Country.INDIA)
            {
                throw new CSVAdapterFactory("No such country", CSVAdapterFactory.ExceptionType.NO_SUCH_COUNTRY);
            }
        }
    }
}