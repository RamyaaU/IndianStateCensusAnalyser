using IndianStateCensusAnalyser.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace IndianStateCensusAnalyser
{
    public class StateCensusAnalyser
    {
        public enum Country
        {
            INDIA
        }

        /// <summary>
        /// The census data map
        /// </summary>
        /// creating a dictionary keeping string as key and censusDto as value
        Dictionary<string, CensusDTO> censusDataMap;

        /// <summary>
        /// Loads the census data.
        /// </summary>
        /// <param name="csvPath">The CSV path.</param>
        /// <param name="country">The country.</param>
        /// <param name="csvHeader">The CSV header.</param>
        /// <returns></returns>
        //creating a dictionary keeping string as key and censusDto as value and passing LoadCensusData along with parameters
        public Dictionary<string, CensusDTO> LoadCensusData(string csvPath, Country country, string csvHeader)
        {
            //checks the exception
            CensusAnalyserException.CheckExceptions(csvPath, country);
            censusDataMap = new CensusAnalyser().LoadDictionary(csvPath, country, csvHeader);
            return censusDataMap;
        }
    }
}