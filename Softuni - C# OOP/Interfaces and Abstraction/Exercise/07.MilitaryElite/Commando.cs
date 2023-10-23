using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite
{
    class Commando : SpecialisedSoldier, ICommando
    {
        private List<Mission> missions;
        public Commando(int id, string firstName, string lastName, decimal salary, string corps,List<Mission> missions)
           : base(id, firstName, lastName, salary, corps)
        {
            this.Missions = missions;
        }
        public List<Mission> Missions { get; set; }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendLine($"Name: {this.FirstName} {this.LastName} Id: {this.Id} Salary: {this.Salary:f2}");
            builder.AppendLine($"Corps: {this.Corps}");
            builder.AppendLine($"Missions:");
            foreach (var mission in this.Missions)
            {
                builder.AppendLine($"  {mission.ToString()}");
            }
            return builder.ToString().TrimEnd();
        }
    }
}
