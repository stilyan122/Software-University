using System;
using System.Linq;
using System.Collections.Generic;

namespace Students
{
    class Students
    {
        static void Main(string[] args)
        {
            List<Student> students = new List<Student>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] studentInput = Console.ReadLine().Split();
                string firstName = studentInput[0];
                string lastName = studentInput[1];
                double grade = double.Parse(studentInput[2]);
                Student student = new Student(firstName, lastName, grade);
                students.Add(student);
            }
            students = students.OrderByDescending(x => x.Grade).ToList();
            foreach (var student in students)
            {
                Console.WriteLine($"{student.FirstName} {student.LastName}: {student.Grade:f2}");
            }
        }
    }
    public class Student
    {
        private string firstName;
        private string lastName;
        private double grade;
        public Student(string firstName, string lastName, double grade)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Grade = grade;
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public double Grade { get; set; }
    }
}
