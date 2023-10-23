using System;
using System.Collections.Generic;
using System.Text;

namespace ExplicitInterfaces
{
    public class Citizen : IPerson, IResident
    {
        private string name;
        private int age;
        private string country;

        public Citizen(string name, int age, string country)
        {
            this.Name = name;
            this.Age = age;
            this.Country = country;
        }
        public string Name { get; set ; }
        public int Age { get; set; }
        public string Country { get ; set; }

        public void GetName()
        {
            Console.WriteLine(this.Name);
            Console.WriteLine("Mr/Ms/Mrs " + this.Name);
        }
    }
}
