﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace IndianStateCensusAnalyser
{
    public class GetCSVRecords
    {
        string[] records;

        /// <summary>
        /// Gets the records.
        /// </summary>
        /// <param name="path">The path.</param>
        /// <param name="header">The header.</param>
        /// <returns></returns>
        /// <exception cref="CSVAdapterFactory">Header is Invalid</exception>
        public string[] GetRecords(string path, string header)
        {
            records = File.ReadAllLines(path);
            if (records[0] != header)
            {
                throw new CSVAdapterFactory("Header is Invalid", CSVAdapterFactory.ExceptionType.INCORRECT_HEADER);
            }
            return records;
        }
    }
}