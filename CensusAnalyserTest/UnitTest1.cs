using IndianStateCensusAnalyser;
using IndianStateCensusAnalyser.DTO;
using NUnit.Framework;
using System.Collections.Generic;
using static IndianStateCensusAnalyser.StateCensusAnalyser;


namespace CensusAnalyserTest
{
    public class Tests
    {
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

        StateCensusAnalyser stateCensusAnalyser;
        Dictionary<string, CensusDTO> stateDataRecord;

        /// <summary>
        /// Setups this instance.
        /// </summary>
        //initialising class instance
        [SetUp]
        public void Setup()
        {
            stateCensusAnalyser = new StateCensusAnalyser();
            stateDataRecord = new Dictionary<string, CensusDTO>();
        }

        /// <summary>
        /// Tests this instance.
        /// </summary>
        [Test]
        public void Test1()
        {
            Assert.Pass();
        }

        /// <summary>
        /// TC 1.1
        /// Given the indian state census data file when read should return census data count.
        /// </summary>
        [Test]
        public void GivenIndianStateCensusDataFile_WhenReaded_ShouldReturnCensusDataCount()
        {
            stateDataRecord = stateCensusAnalyser.LoadCensusData(indianStateCensusDataCSVPath, Country.INDIA, indianStateCensusDataHeader);

            Assert.AreEqual(29, stateDataRecord.Count);
        }

        /// TC 1.2
        /// <summary>
        /// Given the indian state census data wrong file path when read should return custom exception.
        /// </summary>
        [Test]
        public void GivenIndianStateCensusDataWrongFilePath_WhenReaded_ShouldReturnCustomException()
        {
            try
            {
                stateDataRecord = stateCensusAnalyser.LoadCensusData(indianStateCensusDataWrongCSVPath, Country.INDIA, indianStateCensusDataHeader);
            }
            catch (CensusAnalyserException e)
            {
                Assert.AreEqual(CensusAnalyserException.ExceptionType.FILE_NOT_FOUND, e.eType);
            }
        }

        /// TC 1.3
        /// <summary>
        /// Given the indian state census data wrong file type when read should return custom exception.
        /// </summary>
        [Test]
        public void GivenIndianStateCensusDataWrongFileType_WhenReaded_ShouldReturnCustomException()
        {
            try
            {
                stateDataRecord = stateCensusAnalyser.LoadCensusData(indianStateCensusDataWrongType, Country.INDIA, indianStateCensusDataHeader);
            }
            catch (CensusAnalyserException e)
            {
                Assert.AreEqual(CensusAnalyserException.ExceptionType.INVALID_FILE_TYPE, e.eType);
            }
        }

        /// TC 1.4
        /// <summary>
        /// Given the indian state census data file wrong delimiter when read should return custom exception.
        /// </summary>
        [Test]
        public void GivenIndianStateCensusDataFileWrongDelimiter_WhenReaded_ShouldReturnCustomException()
        {
            try
            {
                stateDataRecord = stateCensusAnalyser.LoadCensusData(indianStateCensusDataDelimeter, Country.INDIA, indianStateCensusDataHeader);
            }
            catch (CensusAnalyserException e)
            {
                Assert.AreEqual(CensusAnalyserException.ExceptionType.INCORRECT_DELIMITER, e.eType);
            }
        }

        /// TC 1.5
        /// <summary>
        /// Given the indian state census data file wrong header when read should return custom exception.
        /// </summary>
        [Test]
        public void GivenIndianStateCensusDataFileWrongHeader_WhenRead_ShouldReturnCustomException()
        {
            try
            {
                stateDataRecord = stateCensusAnalyser.LoadCensusData(indianStateCensusDataWrongHeader, Country.INDIA, indianStateCensusDataHeader);
            }
            catch (CensusAnalyserException e)
            {
                Assert.AreEqual(CensusAnalyserException.ExceptionType.INCORRECT_HEADER, e.eType);
            }
        }
    }
}