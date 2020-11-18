using IndianStateCensusAnalyser;
using IndianStateCensusAnalyser.DTO;
using NUnit.Framework;
using System.Collections.Generic;
using static IndianStateCensusAnalyser.CensusAnalyser;

namespace CensusAnalyserTest
{
    public class Tests
    {
        //header definition stored in string
        static string indianStateCensusHeaders = "State,Population,AreaInSqKm,DensityPerSqKm";
        static string indianStateCodeHeaders = "SrNo,State Name,TIN,StateCode";
        //file path for indian state census csv file
        static string indianStateCensusFilePath = @"C:\Users\admin\source\repos\IndianStateCensusAnalyser\CensusAnalyserTest\CSVFiles\IndiaStateCensusData - IndiaStateCensusData.csv";
        //file path for indian state code csv file
        static string indianStateCodeFilePath = @"C:\Users\admin\source\repos\IndianStateCensusAnalyser\CensusAnalyserTest\CSVFiles\IndiaStateCode - IndiaStateCode.csv";
        //file path for wrong header csv file
        static string wrongHeaderIndianStateCensusFilePath = @"C:\Users\admin\source\repos\IndianStateCensusAnalyser\CensusAnalyserTest\CSVFiles\WrongIndiaStateCensusData - WrongIndiaStateCensusData.csv";
        //file path for wrong header csv file
        static string wrongHeaderIndianStateCodeFilePath = @"C:\Users\admin\source\repos\IndianStateCensusAnalyser\CensusAnalyserTest\CSVFiles\WrongIndiaStateCode - WrongIndiaStateCode.csv";
        //file path for wrong delimitercsv file
        static string wrongDelimiterIndianStateCensusFilePath = @"C:\Users\admin\source\repos\IndianStateCensusAnalyser\CensusAnalyserTest\CSVFiles\DelimiterIndiaStateCensusData - DelimiterIndiaStateCensusData.csv";
        //file path for wrong delimeter csv file
        static string wrongDelimiterIndianStateCodeFilePath = @"C:\Users\admin\source\repos\IndianStateCensusAnalyser\CensusAnalyserTest\CSVFiles\DelimiterIndiaStateCode - DelimiterIndiaStateCode.csv";
        //file path for wrong state census csv file
        static string wrongIndianStateCensusFilePath = @"C:\Users\admin\source\repos\IndianStateCensusAnalyser\CensusAnalyserTest\CSVFiles\IndiaData.csv";
        //file path for wrong state code csv file
        static string wrongIndianStateCodeFilePath = @"C:\Users\admin\source\repos\IndianStateCensusAnalyser\CensusAnalyserTest\CSVFiles\IndiaStateCode - IndiaStateCode.csv";
        //file path for wrong state file type
        static string wrongIndianStateCensusFileType = @"C:\Users\admin\source\repos\IndianStateCensusAnalyser\CensusAnalyserTest\CSVFiles\IndiaStateCensusData.txt";
        //file path for wrong state code file type
        static string wrongIndianStateCodeFileType = @"C:\Users\admin\source\repos\IndianStateCensusAnalyser\CensusAnalyserTest\CSVFiles\IndiaStateCode.txt";

        IndianStateCensusAnalyser.CensusAnalyser censusAnalyser;
        Dictionary<string, CensusDTO> totalRecord;
        Dictionary<string, CensusDTO> stateRecord;

        /// <summary>
        /// Setups this instance.
        /// </summary>
        [SetUp]
        public void Setup()
        {
            censusAnalyser = new IndianStateCensusAnalyser.CensusAnalyser();
            totalRecord = new Dictionary<string, CensusDTO>();
            stateRecord = new Dictionary<string, CensusDTO>();
        }

        /// TC 1.1
        /// <summary>
        /// Given the indian census data file when read should return census data count.
        /// </summary>
        [Test]
        public void GivenIndianCensusDataFile_WhenRead_ShouldReturnCensusDataCount()
        {
            totalRecord = censusAnalyser.LoadCensusData(Country.INDIA, indianStateCensusFilePath, indianStateCensusHeaders);
            Assert.AreEqual(29, totalRecord.Count);
        }

        /// TC 1.2
        /// <summary>
        /// Given wrong census data file path should return file not found exception
        /// </summary>
        [Test]
        public void GivenWrongIndianCensusDataFile_WhenRead_ShouldReturnCustomException()
        {
           
            var censusException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(Country.INDIA, wrongIndianStateCensusFilePath, indianStateCensusHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.FILE_NOT_FOUND, censusException.eType);
        }

        /// TC 1.3
        /// <summary>
        /// Given wrong census data file type should return custom exception invalid file type
        /// </summary>
        [Test]
        public void GivenWrongIndianCensusDataFileType_WhenRead_ShouldReturnCustomException()
        {
            var censusException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(Country.INDIA, wrongIndianStateCensusFileType, indianStateCensusHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INVALID_FILE_TYPE, censusException.eType);
        }

        /// TC 1.4
        /// <summary>
        /// Given  census data file  wrong delimiter should return custom exception incorrect delimiter exception
        /// </summary>
        [Test]
        public void GivenIndianCensusDataFile_WhenNotProper_ShouldReturnException()
        {
            var censusException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(Country.INDIA, wrongDelimiterIndianStateCensusFilePath, indianStateCensusHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INCORRECT_DELIMITER, censusException.eType);
        }

        /// TC 1.5
        /// <summary>
        /// Givens the indian census data file when header not proper should return exception.
        /// </summary>
        [Test]
        public void GivenIndianCensusDataFile_WhenHeaderNotProper_ShouldReturnException()
        { 
            var censusException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(Country.INDIA, wrongHeaderIndianStateCensusFilePath, indianStateCensusHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INCORRECT_HEADER, censusException.eType);
        }
    }
}
       