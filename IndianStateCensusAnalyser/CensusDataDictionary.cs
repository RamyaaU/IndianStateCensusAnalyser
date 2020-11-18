using IndianStateCensusAnalyser.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace IndianStateCensusAnalyser
{
    public class CensusDataDictionary
    {
        /// <summary>
        /// The data map
        /// </summary>
        //creating a dictionary with string as key and CensusDto as value  and to store data from csv
        public Dictionary<string, CensusDTO> dataMap;

        /// <summary>
        /// Loads the dictionary.
        /// </summary>
        /// <param name="path">The path.</param>
        /// <param name="country">The country.</param>
        /// <param name="header">The header.</param>
        /// <returns></returns>
        /// <exception cref="IndianStateCensusAnalyser.CSVAdapterFactory">No such country</exception>
        //creating a dictionary with string as key and CensusDto to store data from csv as value and loaddictionary is passed with parameters
        public Dictionary<string, CensusDTO> LoadDictionary(string path, StateCensusAnalyser.Country country, string header)
        {
            if (country != StateCensusAnalyser.Country.INDIA)
            {
                throw new CSVAdapterFactory("No such country", CSVAdapterFactory.ExceptionType.NO_SUCH_COUNTRY);
            }
            dataMap = new IndianCensusDictionary().GetDictionary(path, header);
            return dataMap;
        }
    }
}
