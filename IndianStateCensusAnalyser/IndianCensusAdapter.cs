using IndianStateCensusAnalyser.DTO;
using IndianStateCensusAnalyser.POCO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IndianStateCensusAnalyser
{
    public class IndianCensusAdapter : CensusAdapter
    {
        string[] censusData;
        // dictionary to store the data from the CSV files keeping string as key
        // censusuDto as value
        Dictionary<string, CensusDTO> dataMap;
        /// <summary>
        /// Load census data method return the map dictionary of data loaded from the csv files.
        /// </summary>
        /// <param name="csvFilePath">The CSV file path.</param>
        /// <param name="dataHeaders">The data headers.</param>
        /// <returns></returns>
        /// <exception cref="IndianStatesCensusAnalyser.POCO.CensusAnalyserException">File Contains Wrong Delimiter</exception>
        public Dictionary<string, CensusDTO> LoadCensusData(string csvFilePath, string dataHeaders)
        {
            dataMap = new Dictionary<string, CensusDTO>();
            censusData = GetCensusData(csvFilePath, dataHeaders);
            /// Iterating over the censusData 
            foreach (string data in censusData.Skip(1))
            {
                // if the data does not contain delimeter i.e comma
                // then it throws exception
                if (!data.Contains(","))
                {
                    throw new CensusAnalyserException("File Contains Wrong Delimiter", CensusAnalyserException.ExceptionType.INCORRECT_DELIMITER);
                }
                // splits the data with comma
                string[] column = data.Split(",");
                // if path contains state code then file will be added
                if (csvFilePath.Contains("IndiaStateCode.csv"))
                    dataMap.Add(column[1], new CensusDTO(new StateCodeDAO(column[0], column[1], column[2], column[3])));
                // if path contains state census code then file will be added
                if (csvFilePath.Contains("IndiaStateCensusData.csv"))
                    dataMap.Add(column[0], new CensusDTO(new CensusDataDAO(column[0], column[1], column[2], column[3])));
            }
            return dataMap.ToDictionary(p => p.Key, p => p.Value);
        }
    }
}
