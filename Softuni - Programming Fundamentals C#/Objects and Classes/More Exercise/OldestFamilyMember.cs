using System;
using System.Collections.Generic;
using System.Linq;

namespace OldestFamilyMember
{
    class OldestFamilyMember
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Family family = new Family();
            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split();
                string name = input[0];
                int age = int.Parse(input[1]);
                Person person = new Person(name, age);
                family.AddMember(person);
            }
            Person oldest = family.GetOldestMember();
            Console.WriteLine(oldest.Name+" "+oldest.Age);
        } 
    }
    public class Person
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
    }
    public class Family
    {
        private List<Person> people;
        public List<Person> People { get; set; }
        public Family()
        {
            this.People = new List<Person>();
        }
        public void AddMember(Person member)
        {
            this.People.Add(member);
        }
        public Person GetOldestMember()
        {
            return this.People.OrderByDescending(x => x.Age).ToList()[0];
        }
    }
}
