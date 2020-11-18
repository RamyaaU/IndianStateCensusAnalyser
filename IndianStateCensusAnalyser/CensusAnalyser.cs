using IndianStateCensusAnalyser.DTO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace IndianStateCensusAnalyser
{
    public class CensusAnalyser
    {
        // declaring enum variables
        public enum Country
        {
            INDIA,
            US,
        }

        // dictionary to store the data from the CSV files keeping string as key
        // censusuDto as value
        Dictionary<string, CensusDTO> dataMap;

        /// <summary>
        /// Function to load the data from Csv files and retuns data map
        /// </summary>
        /// <param name="country">The country.</param>
        /// <param name="csvFilePath">The CSV file path.</param>
        /// <param name="dataHeaders">The data headers.</param>
        /// <returns></returns>
        // dictionary to store the data from the CSV files keeping string as key
        // censusuDto as value and passing loadcensus data along with parameters
        public Dictionary<string, CensusDTO> LoadCensusData(Country country, string csvFilePath, string dataHeaders)
        {
            dataMap = new CSVAdapterFactory().LoadCsvData(country, csvFilePath, dataHeaders);
            return dataMap;
        }
    }
}
