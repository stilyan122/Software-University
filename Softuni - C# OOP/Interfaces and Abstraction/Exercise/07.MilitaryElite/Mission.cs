using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite
{
    public class Mission : IMission
    {
        private string codeName;
        private string state;
        public Mission(string codeName,string state)
        {
            this.State = state;
            this.CodeName = codeName;    
        }
        public string CodeName { get; set; }
        public string State { get; set; }
        public override string ToString()
        {
            return $"Code Name: {this.CodeName} State: {this.State}".ToString();
        }
    }
}
