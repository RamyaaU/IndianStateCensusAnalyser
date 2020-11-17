using IndianStateCensusAnalyser.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace IndianStateCensusAnalyser
{
    public class IndianCensusDictionary
    {
        string[] records;
        //creating a dictionary by passing string as key and censusdto as value and to store data from csv
        Dictionary<string, CensusDTO> dataMap;

        /// <summary>
        /// Gets the dictionary.
        /// </summary>
        /// <param name="path">The path.</param>
        /// <param name="header">The header.</param>
        /// <returns></returns>
        /// <exception cref="IndianStateCensusAnalyser.CensusAnalyserException">Delimiter is Invalid</exception>
        //creating a dictionary by passing string as key and censusdto as value and to store data from csv
        //and gets the data from dictionary by parameters passed
        public Dictionary<string, CensusDTO> GetDictionary(string path, string header)
        {
            dataMap = new Dictionary<string, CensusDTO>();
            //to get records from csv file
            records = new GetCSVRecords().GetRecords(path, header);
            //to iterate in records i is used as an variable 
            for (int i = 1; i < records.Length; i++)
            {
                //if record does not contain ","
                //then it throws an exception
                if (records[i].Contains(",") == false)
                {
                    throw new CensusAnalyserException("Delimiter is Invalid", CensusAnalyserException.ExceptionType.INCORRECT_DELIMITER);
                }
                //here data is split using comma
                string[] info = records[i].Split(",");
                //if path contains State census data then that data will be added
                if (path.Contains("IndiaStateCensusData"))
                    dataMap.Add(info[1], new CensusDTO(new POCO.CensusDataDAO(info[0], info[1], info[2], info[3])));
                //if path contains state code datat then that data will be added
                if (path.Contains("IndiaStateCode"))
                    dataMap.Add(info[1], new CensusDTO(new POCO.StateCodeDAO(info[0], info[1], info[2], info[3])));
            }
            return dataMap;
        }
    }
}