using System;
using System.Collections.Generic;
using System.Linq;

namespace Students20
{
    class Students20
    {
        static void Main(string[] args)
        {
            string[] command = Console.ReadLine().Split();
            List<Student> students = new List<Student>();
            while (command[0] != "end")
            {
                string firstName = command[0];
                string lastName = command[1];
                int age = int.Parse(command[2]);
                string homeTown = command[3];
                Student student = new Student(firstName, lastName, age, homeTown);
                if (students.Where(x => x.FirstName == student.FirstName && x.LastName == student.LastName).ToList().Count != 0)
                {
                    students.Where(x => x.FirstName == student.FirstName && x.LastName == student.LastName).ToList()[0].FirstName = student.FirstName;
                    students.Where(x => x.FirstName == student.FirstName && x.LastName == student.LastName).ToList()[0].LastName = student.LastName;
                    students.Where(x => x.FirstName == student.FirstName && x.LastName == student.LastName).ToList()[0].Age = student.Age;
                    students.Where(x => x.FirstName == student.FirstName && x.LastName == student.LastName).ToList()[0].HomeTown = student.HomeTown;
                }
                else
                {
                    students.Add(student);
                }
                command = Console.ReadLine().Split();
            }
            string city = Console.ReadLine();
            students = students.Where(x => x.HomeTown == city).ToList();
            foreach (var item in students)
            {
                Console.WriteLine($"{item.FirstName} {item.LastName} is {item.Age} years old.");
            }
        }
    }
    public class Student
    {
        private string firstName;
        private string lastName;
        private int age;
        private string homeTown;
        public Student(string firstName, string lastName, int age, string homeTown)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Age = age;
            this.HomeTown = homeTown;
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string HomeTown { get; set; }
    }
}
