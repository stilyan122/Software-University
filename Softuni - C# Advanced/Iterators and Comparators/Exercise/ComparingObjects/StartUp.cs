using System;
using System.Collections.Generic;

namespace ComparingObjects
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Person> people = new List<Person>();
            string[] info = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);
            int matches = 0;
            int nonMatches = 0;
            while (info[0] != "END")
            {
                string name = info[0];
                int age = int.Parse(info[1]);
                string town = info[2];
                Person person = new Person(name, age, town);
                people.Add(person);
                info = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);
            }
            int n = int.Parse(Console.ReadLine());
            Person personToFind = people[n - 1];
            if (people.Count > 0)
            {
                foreach (var item in people)
                {
                    if (personToFind.CompareTo(item)==0)
                    {
                        matches++;
                    }
                    else
                    {
                        nonMatches++;
                    }
                }
            }
            int counter = people.Count;
            if(matches>1)
                Console.WriteLine(matches+" "+nonMatches+" "+counter);
            else
                Console.WriteLine("No matches");
        }
    }
}
