using IndianStateCensusAnalyser.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace IndianStateCensusAnalyser
{
    public class IndianCensusDictionary
    {
        string[] records;

        /// <summary>
        /// The census data map
        /// </summary>
        /// creating a dictionary keeping string as key and censusDto as value
        Dictionary<string, CensusDTO> censusDataMap;

        /// <summary>
        /// Gets the dictionary.
        /// </summary>
        /// <param name="path">The path.</param>
        /// <param name="header">The header.</param>
        /// <returns></returns>
        /// <exception cref="CSVAdapterFactory">Delimiter is Invalid</exception>
        public Dictionary<string, CensusDTO> GetDictionary(string path, string header)
        {
            //creates a dictionary keeping as string as key and CensusDTO as value
            censusDataMap = new Dictionary<string, CensusDTO>();
            //gets the records
            records = new GetCSVRecords().GetRecords(path, header);
            for (int i = 1; i < records.Length; i++)
            {
                if (records[i].Contains(",") == false)
                {
                    throw new CSVAdapterFactory("Delimiter is Invalid", CSVAdapterFactory.ExceptionType.INCORRECT_DELIMITER);
                }
                string[] info = records[i].Split(",");
                censusDataMap.Add(info[1], new CensusDTO(new POCO.CensusDataDAO(info[0], info[1], info[2], info[3])));
            }
            return censusDataMap;
        }
    }
}
