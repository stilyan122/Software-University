using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite
{
    public class Spy : Soldier, ISpy
    {
        private int codeNumber;
        public Spy(int id, string firstName, string lastName,int codeNumber)
            :base(id,firstName,lastName)
        {
            this.CodeNumber = codeNumber;
        }
        public int CodeNumber { get; set; }
        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendLine($"Name: {this.FirstName} {this.LastName} Id: {this.Id}");
            builder.AppendLine($"Code Number: {this.CodeNumber}");
            return builder.ToString().TrimEnd();
        }
    }
}
