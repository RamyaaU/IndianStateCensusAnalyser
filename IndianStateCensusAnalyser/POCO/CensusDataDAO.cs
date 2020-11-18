using System;
using System.Collections.Generic;
using System.Text;

namespace IndianStateCensusAnalyser.POCO
{
    public class CensusDataDAO
    {
        public string state;
        public string population;
        public string area;
        public string density;

        /// <summary>
        /// Initializes a new instance of the <see cref="CensusDataDAO"/> class.
        /// </summary>
        /// <param name="state">The state.</param>
        /// <param name="population">The population.</param>
        /// <param name="area">The area.</param>
        /// <param name="density">The density.</param>
        public CensusDataDAO(string state, string population, string area, string density)
        {
            this.state = state;
            this.population = population;
            this.area = area;
            this.density = density;
        }
    }
}