using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite
{
    public class Engineer : SpecialisedSoldier, IEngineer
    {
        private List<Repair> repairs;

        public Engineer(int id, string firstName,string lastName,decimal salary, string corps,List<Repair> repairs)
            :base(id,firstName,lastName,salary,corps)
        {
            this.Repairs = repairs;
        }
        public List<Repair> Repairs { get; set; }
        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendLine($"Name: {this.FirstName} {this.LastName} Id: {this.Id} Salary: {this.Salary:f2}");
            builder.AppendLine($"Corps: {this.Corps}");
            builder.AppendLine($"Repairs:");
            foreach (var repairPerson in this.Repairs)
            {
                builder.AppendLine($"  {repairPerson.ToString()}");
            }
            return builder.ToString().TrimEnd();
        }
    }
}
