using IndianStateCensusAnalyser.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace IndianStateCensusAnalyser
{
    public class CensusDataDictionary
    {
        public Dictionary<string, CensusDTO> censusDataMap;
        public Dictionary<string, CensusDTO> LoadDictionary(string path, StateCensusAnalyser.Country country, string header)
        {
            if (country == StateCensusAnalyser.Country.INDIA)
            {
                censusDataMap = new IndianCensusDictionary().GetDictionary(path, header);
            }

            return censusDataMap;
        }
    }
}
