using System;
using System.Linq;
using System.Collections.Generic;

namespace Courses
{
    class Courses
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> courses = new Dictionary<string, List<string>>();
            string[] input = Console.ReadLine().Split(" : ", StringSplitOptions.RemoveEmptyEntries);
            while (input[0]!="end")
            {
                string course = input[0];
                string name = input[1];
                if (!courses.ContainsKey(course))
                {
                    courses.Add(course, new List<string>() { name });
                }
                else
                {
                    courses[course].Add(name);
                }
                input = Console.ReadLine().Split(" : ", StringSplitOptions.RemoveEmptyEntries);
            }
            foreach (var course in courses)
            {
                Console.WriteLine(course.Key+": "+course.Value.Count);
                foreach (var person in course.Value)
                {
                    Console.WriteLine("-- "+person);
                }
            }
        }
    }
}
