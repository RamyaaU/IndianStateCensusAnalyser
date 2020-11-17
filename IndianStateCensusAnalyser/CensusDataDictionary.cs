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
        //creating a dictionary with string as key and CensusDto as value
        public Dictionary<string, CensusDTO> dataMap;

        /// <summary>
        /// Loads the dictionary.
        /// </summary>
        /// <param name="path">The path.</param>
        /// <param name="country">The country.</param>
        /// <param name="header">The header.</param>
        /// <returns></returns>
        /// <exception cref="IndianStateCensusAnalyser.CensusAnalyserException">No such country</exception>
        //creating a dictionary with string as key and CensusDto as value and loaddictionary is passed with parameters
        public Dictionary<string, CensusDTO> LoadDictionary(string path, StateCensusAnalyser.Country country, string header)
        {
            if (country != StateCensusAnalyser.Country.INDIA)
            {
                throw new CensusAnalyserException("No such country", CensusAnalyserException.ExceptionType.NO_SUCH_COUNTRY);
            }
            dataMap = new IndianCensusDictionary().GetDictionary(path, header);
            return dataMap;
        }
    }
}
