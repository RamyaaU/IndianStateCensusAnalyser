using IndianStateCensusAnalyser.DTO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace IndianStateCensusAnalyser
{
    public abstract class CensusAdapter
    {
        /// <summary>
        /// Gets the census data.
        /// </summary>
        /// <param name="csvFilePath">The CSV file path.</param>
        /// <param name="dataHeaders">The data headers.</param>
        /// <returns></returns>
        /// <exception cref="IndianStateCensusAnalyser.CensusAnalyserException">
        /// File Not Found
        /// or
        /// Invalid File Type
        /// or
        /// Incorrect header in Data
        /// </exception>
        protected string[] GetCensusData(string csvFilePath, string dataHeaders)
        {
            string[] censusData;
            // checks if the file exists, If not it throws the custom exception 
            // for that file
            if (!File.Exists(csvFilePath))
            {
                throw new CensusAnalyserException("File Not Found", CensusAnalyserException.ExceptionType.FILE_NOT_FOUND);
            }
            // checks for that path if that path doesnot match tehn it throws exception saying inavlid file type
            if (Path.GetExtension(csvFilePath) != ".csv")
            {
                throw new CensusAnalyserException("Invalid File Type", CensusAnalyserException.ExceptionType.INVALID_FILE_TYPE);
            }
            // reads all the lines from the file
            censusData = File.ReadAllLines(csvFilePath);
            // matches the file header with the given data headers
            // if header is incorrect then it throws the exception 
            if (censusData[0] != dataHeaders)
            {
                throw new CensusAnalyserException("Incorrect header in Data", CensusAnalyserException.ExceptionType.INCORRECT_HEADER);
            }
            return censusData;
        }
    }
}
