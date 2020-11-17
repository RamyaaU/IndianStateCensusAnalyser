using IndianStateCensusAnalyser;
using IndianStateCensusAnalyser.DTO;
using NUnit.Framework;
using System.Collections.Generic;
using static IndianStateCensusAnalyser.StateCensusAnalyser;

namespace CensusAnalyserTest1
{
    public class Tests
    {
        //file paths for StateCensusData
        //header definition stored in string
        string indianStateCensusDataHeader = "State,Population,AreaInSqKm,DensityPerSqKm";
        //state file path
        string indianStateCensusDataCSVPath = @"C:\Users\admin\source\repos\IndianStateCensusAnalyser\CensusAnalyserTest\CSVFiles\IndiaStateCensusData - IndiaStateCensusData.csv";
        //wrong file path
        string indianStateCensusDataWrongCSVPath = @"C:\Users\admin\source\repos\IndianStateCensusAnalyser\CensusAnalyserTest\CSVFiles\IndiaStateCensusData - IndiaStateCensusData.csv";
        //wrong data type
        string indianStateCensusDataWrongType = @"C:\Users\admin\source\repos\IndianStateCensusAnalyser\CensusAnalyserTest\CSVFiles\IndiaStateCode.txt";
        //wrong delimeter
        string indianStateCensusDataDelimeter = @"C:\Users\admin\source\repos\IndianStateCensusAnalyser\CensusAnalyserTest\CSVFiles\DelimiterIndiaStateCensusData - DelimiterIndiaStateCensusData.csv";
        //wrong header 
        string indianStateCensusDataWrongHeader = @"C:\Users\admin\source\repos\IndianStateCensusAnalyser\CensusAnalyserTest\CSVFiles\WrongIndiaStateCensusData - WrongIndiaStateCensusData.csv";

        //file paths for StateCodeData
        //header definition stored in string
        string indianStateCodeHeader = "SrNo,State Name,TIN,StateCode";
        //state code path
        string indiaStateCodeCSVPath = @"C:\Users\admin\source\repos\IndianStateCensusAnalyser\CensusAnalyserTest1\CSVFiles\IndiaStateCode - IndiaStateCode.csv";
        //state code worng path
        string indianStateCodeWrongCSVPath = @"C:\Users\admin\source\repos\IndianStateCensusAnalyser\CensusAnalyserTest1\CSVFiles\IndiaStateCode - IndiaStateCode.csv";
        //state code wrong file type
        string indianStateCodeWrongFileType = @"C:\Users\admin\source\repos\IndianStateCensusAnalyser\CensusAnalyserTest1\CSVFiles\IndiaStateCode.txt";
        //state code delimeter path
        string indianStateStateCodeDelimeter = @"C:\Users\admin\source\repos\IndianStateCensusAnalyser\CensusAnalyserTest1\CSVFiles\DelimiterIndiaStateCode - DelimiterIndiaStateCode.csv";
        //state code wrong header path
        string indianStateCodeWrongHeader = @"C:\Users\admin\source\repos\IndianStateCensusAnalyser\CensusAnalyserTest1\CSVFiles\WrongIndiaStateCode - WrongIndiaStateCode.csv";

        StateCensusAnalyser stateCensusAnalyser;
        Dictionary<string, CensusDTO> censusDataRecord;
        Dictionary<string, CensusDTO> stateCodeRecord;

        /// <summary>
        /// Setups this instance.
        /// </summary>
        //initilaizing class instance
        [SetUp]
        public void Setup()
        {
            stateCensusAnalyser = new StateCensusAnalyser();
            censusDataRecord = new Dictionary<string, CensusDTO>();
            stateCodeRecord = new Dictionary<string, CensusDTO>();
        }

        /// <summary>
        /// Test1s this instance.
        /// </summary>
        [Test]
        public void Test1()
        {
            Assert.Pass();
        }

        /// TC 2.1
        /// <summary>
        /// Given the indian state code data file when read should return census data count.
        /// </summary>
        [Test]
        public void GivenIndianStateCodeDataFile_WhenRead_ShouldReturnCensusDataCount()
        {
            stateCodeRecord = stateCensusAnalyser.LoadCensusData(indiaStateCodeCSVPath, Country.INDIA, indianStateCodeHeader);

            Assert.AreEqual(37, stateCodeRecord.Count);
        }

        /// TC 2.2
        /// <summary>
        /// Given the indian state code wrong file path when read should return custom exception.
        /// </summary>
        [Test]
        public void GivenIndianStateCodeWrongFilePath_WhenRead_ShouldReturnCustomException()
        {
            try
            {
                stateCodeRecord = stateCensusAnalyser.LoadCensusData(indianStateCodeWrongCSVPath, Country.INDIA, indianStateCodeHeader);
            }
            catch (CensusAnalyserException e)
            {
                Assert.AreEqual(CensusAnalyserException.ExceptionType.FILE_NOT_FOUND, e.eType);
            }
        }

        /// TC 2.3
        /// <summary>
        /// Given the indian state code wrong file type when read should return custom exception.
        /// </summary>
        [Test]
        public void GivenIndianStateCodeWrongFileType_WhenRead_ShouldReturnCustomException()
        {
            try
            {
                stateCodeRecord = stateCensusAnalyser.LoadCensusData(indianStateCodeWrongFileType, Country.INDIA, indianStateCodeHeader);
            }
            catch (CensusAnalyserException e)
            {
                Assert.AreEqual(CensusAnalyserException.ExceptionType.INVALID_FILE_TYPE, e.eType);
            }
        }

        /// TC 2.4
        /// <summary>
        /// Given the indian state code file wrong delimiter when read should return custom exception.
        /// </summary>
        [Test]
        public void GivenIndianStateCodeFileWrongDelimiter_WhenReaded_ShouldReturnCustomException()
        {
            try
            {
                stateCodeRecord = stateCensusAnalyser.LoadCensusData(indianStateStateCodeDelimeter, Country.INDIA, indianStateCodeHeader);
            }
            catch (CensusAnalyserException e)
            {
                Assert.AreEqual(CensusAnalyserException.ExceptionType.INCORRECT_DELIMITER, e.eType);
            }
        }

        /// TC 2.5
        /// <summary>
        /// Given the indian state code file wrong header when read should return custom exception.
        /// </summary>
        [Test]
        public void GivenIndianStateCodeFileWrongHeader_WhenRead_ShouldReturnCustomException()
        {
            try
            {
                stateCodeRecord = stateCensusAnalyser.LoadCensusData(indianStateCodeWrongHeader, Country.INDIA, indianStateCodeHeader);
            }
            catch (CensusAnalyserException e)
            {
                Assert.AreEqual(CensusAnalyserException.ExceptionType.INCORRECT_HEADER, e.eType);
            }
        }
    }
}
