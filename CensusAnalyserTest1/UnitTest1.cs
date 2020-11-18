using IndianStateCensusAnalyser;
using IndianStateCensusAnalyser.DTO;
using NUnit.Framework;
using System.Collections.Generic;
using static IndianStateCensusAnalyser.CensusAnalyser;

namespace CensusAnalyserTest
{
    public class Tests
    {
        //definition for header
        static string indianStateCodeHeaders = "SrNo,State Name,TIN,StateCode";

        //file path for indian state code csv file
        static string indianStateCodeFilePath = @"C:\Users\admin\source\repos\IndianStateCensusAnalyser\CensusAnalyserTest1\CSVFiles\IndiaStateCode - IndiaStateCode.csv";

        //file path for wrong header csv file
        static string wrongHeaderIndianStateCodeFilePath = @"C:\Users\admin\source\repos\IndianStateCensusAnalyser\CensusAnalyserTest1\CSVFiles\WrongIndiaStateCode - WrongIndiaStateCode.csv";

        //file path for wrong delimeter csv file
        static string wrongDelimiterIndianStateCodeFilePath = @"C:\Users\admin\source\repos\IndianStateCensusAnalyser\CensusAnalyserTest1\CSVFiles\DelimiterIndiaStateCode - DelimiterIndiaStateCode.csv";

        //file path for wrong state code csv file
        static string wrongIndianStateCodeFilePath = @"C:\Users\admin\source\repos\IndianStateCensusAnalyser\CensusAnalyserTest1\CSVFiles\IndiaStateCode - IndiaStateCode.csv";

        //file path for wrong state code file type
        static string wrongIndianStateCodeFileType = @"C:\Users\admin\source\repos\IndianStateCensusAnalyser\CensusAnalyserTest1\CSVFiles\IndiaStateCode.txt";

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

        /// TC 2.1
        /// <summary>
        /// Givens the indian state code data file when readed should return census data count.
        /// </summary>
        [Test]
        public void GivenIndianStateCodeDataFile_WhenReaded_ShouldReturnCensusDataCount()
        {
            stateRecord = censusAnalyser.LoadCensusData(Country.INDIA, indianStateCodeFilePath, indianStateCodeHeaders);
            Assert.AreEqual(37, stateRecord.Count);
        }

        /// TC 2.2
        /// <summary>
        /// Givens the wrong indian state code data file when readed should return custom exception.
        /// </summary>
        public void GivenWrongIndianCensusDataFile_WhenRead_ShouldReturnCustomException()
        {
            var censusException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(Country.INDIA, wrongIndianStateCodeFilePath, indianStateCodeHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.FILE_NOT_FOUND, censusException.eType);
        }


        /// TC 2.3
        /// <summary>
        /// Givens the wrong indian state code file type when readed should return custom exception.
        /// </summary>
        [Test]
        public void GivenWrongIndianStateCodeFileType_WhenReaded_ShouldReturnCustomException()
        {
            var stateException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(Country.INDIA, wrongIndianStateCodeFileType, indianStateCodeHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INVALID_FILE_TYPE, stateException.eType);
        }

        ///TC 2.4
        /// <summary>
        /// Given  state code data file  wrong delimiter should return custom exception incorrect delimiter exception
        /// </summary>
        [Test]
        public void GivenIndianStateCodeDataFile_WhenNotProper_ShouldReturnException()
        {
            var stateException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(Country.INDIA, wrongDelimiterIndianStateCodeFilePath, indianStateCodeHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INCORRECT_DELIMITER, stateException.eType);
        }

        ///TC 2.5
        /// <summary>
        /// Given  state code data file incorrect headers should return custom exception incorrect delimiter exception
        /// </summary>
        [Test]
        public void givenIndianStateCodeDataFile_WhenHeaderNotProper_ShouldReturnException()
        {
            var stateException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(Country.INDIA, wrongHeaderIndianStateCodeFilePath, indianStateCodeHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INCORRECT_HEADER, stateException.eType);
        }
    }
}