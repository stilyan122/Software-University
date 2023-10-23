using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite
{
    public class LieutenantGeneral : Private, ILieutenantGeneral
    {
        private List<Private> privates;

        public LieutenantGeneral(int id, string firstName, string lastName, decimal salary,List<Private> privates)
            :base(id,firstName,lastName,salary)
        {
            this.Privates = privates;
        }
        public List<Private> Privates { get; set; }
        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendLine($"Name: {this.FirstName} {this.LastName} Id: {this.Id} Salary: {this.Salary:f2}");
            builder.AppendLine("Privates:");
            foreach (var privatePerson in this.Privates)
            {
                builder.AppendLine($"  {privatePerson.ToString()}");
            }
            return builder.ToString().TrimEnd();
        }
    }
}
