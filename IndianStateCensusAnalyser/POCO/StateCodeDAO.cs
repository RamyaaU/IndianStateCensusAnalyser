using System;
using System.Collections.Generic;
using System.Text;

namespace IndianStateCensusAnalyser.POCO
{
    public class StateCodeDAO
    {
        public int srNo;
        public string stateName;
        public int tin;
        public string stateCode;

        /// <summary>
        /// Initializes a new instance of the <see cref="StateCodeDAO"/> class.
        /// </summary>
        /// <param name="srNo">The sr no.</param>
        /// <param name="stateName">Name of the state.</param>
        /// <param name="tin">The tin.</param>
        /// <param name="stateCode">The state code.</param>
        public StateCodeDAO(string srNo, string stateName, string tin, string stateCode)
        {
            this.srNo = Convert.ToInt32(srNo);
            this.stateName = stateName;
            this.tin = Convert.ToInt32(tin);
            this.stateCode = stateCode;
        }
    }
}