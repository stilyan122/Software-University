using System;
using System.Collections.Generic;
using System.Linq;

namespace OrderByAge
{
    class OrderByAge
    {
        static void Main(string[] args)
        {
            List<Person> people = new List<Person>();
            string[] command = Console.ReadLine().Split();
            while (command[0]!="End")
            {
                string name = command[0];
                string id = command[1];
                int age = int.Parse(command[2]);
                Person person = new Person(name, id, age);
                if (people.Where(x=>x.Id==id).Any())
                {
                    people.Where(x => x.Id == id).ToList()[0].Name = name;
                    people.Where(x => x.Id == id).ToList()[0].Age = age;
                }
                people.Add(person);
                command = Console.ReadLine().Split();
            }
            people = people.OrderBy(x => x.Age).ToList();
            foreach (var person in people)
            {
                Console.WriteLine($"{person.Name} with ID: {person.Id} is {person.Age} years old.");
            }
        }
    }
    public class Person
    {
        private string name;
        private string id;
        private int age;
        public Person(string name, string id, int age)
        {
            this.Name = name;
            this.Id = id;
            this.Age = age;
        }
        public string Name { get; set; }
        public string Id { get; set; }
        public int Age { get; set; }
    }
}
