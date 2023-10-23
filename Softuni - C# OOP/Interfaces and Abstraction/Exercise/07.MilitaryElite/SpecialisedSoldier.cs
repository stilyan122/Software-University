using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite
{
    public class SpecialisedSoldier : Private, ISpecialisedSoldier
    {
        private string corps;
        public SpecialisedSoldier(int id, string firstName, string lastName, decimal salary,string corps)
           : base(id, firstName, lastName, salary)
        {
            this.Corps = corps;
        }
        public string Corps {
            get
            {
                return corps;
            }
            set
            {
              corps = value;
            }
        }
    }
}
