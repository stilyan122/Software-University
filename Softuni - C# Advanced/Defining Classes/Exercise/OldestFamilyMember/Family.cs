using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DefiningClasses
{
    public class Family
    {
        private List<Person> people;
        public Family()
        {
            this.People = new List<Person>();
        }
        public List<Person> People { get; set; }
        public void AddMember(Person person)
        {
            this.People.Add(person);
        }
        public Person GetOldestMember()
        {
            return People.OrderByDescending(x => x.Age).ToList()[0];
        }
    }
}
