using System;
using System.Collections.Generic;
using System.Text;

namespace IndianStateCensusAnalyser.DTO
{
    public class CensusDTO
    {
        public int srNo;
        public string stateName;
        public int tin;
        public string stateCode;
        public string state;
        public long population;
        public long area;
        public long density;

        /// <summary>
        /// Initializes a new instance of the <see cref="CensusDTO"/> class.
        /// </summary>
        /// <param name="stateCodeDAO">The state code DAO.</param>
        public CensusDTO(StateCodeDAO stateCodeDAO)
        {
            this.srNo = stateCodeDAO.srNo;
            this.stateName = stateCodeDAO.stateName;
            this.tin = stateCodeDAO.tin;
            this.stateCode = stateCodeDAO.stateCode;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CensusDTO"/> class.
        /// </summary>
        /// <param name="censusDataDAO">The census data DAO.</param>
        public CensusDTO(CensusDataDAO censusDataDAO)
        {
            this.state = censusDataDAO.state;
            this.population = censusDataDAO.population;
            this.area = censusDataDAO.area;
            this.density = censusDataDAO.density;
        }
    }
}