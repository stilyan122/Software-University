using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite
{
    public class Soldier : ISoldier
    {
        private int id;
        private string firstName;
        private string lastName;

        public Soldier(int id,string firstName,string lastName)
        {
            this.Id = id;
            this.FirstName = firstName;
            this.LastName = lastName;
        }
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
