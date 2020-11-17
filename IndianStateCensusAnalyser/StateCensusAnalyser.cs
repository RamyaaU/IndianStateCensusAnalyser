using IndianStateCensusAnalyser.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace IndianStateCensusAnalyser
{
    public class StateCensusAnalyser
    {
        /// <summary>
        /// declaring enum variable
        /// </summary>
        public enum Country
        {
            INDIA
        }

        //creating dictionary by passing string as key and censusdto as value and to store data from csv
        Dictionary<string, CensusDTO> dataMap;

        /// <summary>
        /// Loads the census data.
        /// </summary>
        /// <param name="csvPath">The CSV path.</param>
        /// <param name="country">The country.</param>
        /// <param name="csvHeader">The CSV header.</param>
        /// <returns></returns>
        //creating a dictionary by passing string as key and censusdto as value and to store data from csv
        //and gets the data from dictionary by parameters passed
        public Dictionary<string, CensusDTO> LoadCensusData(string csvPath, Country country, string csvHeader)
        {
            CheckFileExceptions.CheckExceptions(csvPath);
            dataMap = new CensusDataDictionary().LoadDictionary(csvPath, country, csvHeader);
            return dataMap;
        }
    }
}