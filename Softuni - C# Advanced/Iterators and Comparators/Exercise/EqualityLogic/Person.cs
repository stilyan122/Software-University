using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EqualityLogic
{
    public class Person : IComparable<Person>
    {
        private string name;
        private int age;
        public Person(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }
        public string Name { get; set; }
        public int Age { get; set; }

        public int CompareTo(Person other)
        {
            int names = Name.CompareTo(other.Name);
            return names == 0 ? Age.CompareTo(other.Age) : names;
        }
    }
}
