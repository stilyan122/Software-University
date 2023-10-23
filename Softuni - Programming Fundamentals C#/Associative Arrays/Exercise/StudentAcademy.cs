using System;
using System.Collections.Generic;
using System.Linq;

namespace StudentAcademy
{
    class StudentAcademy
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<string, List<double>> students = new Dictionary<string, List<double>>();
            Dictionary<string, double> averages = new Dictionary<string, double>();
            for (int i = 0; i < n; i++)
            {
                string name = Console.ReadLine();
                double grade = double.Parse(Console.ReadLine());
                if (!students.ContainsKey(name))
                {
                    students.Add(name, new List<double>() { grade });
                }
                else
                {
                    students[name].Add(grade);
                }
            }
            foreach (var student in students)
            {
                averages.Add(student.Key, student.Value.Average());
            }
            List<KeyValuePair<string, double>> sorted = averages.Where(x => x.Value >= 4.50).ToList();
            foreach (var item in sorted)
            {
                Console.WriteLine($"{item.Key} -> {item.Value:f2}");
            }
        }
    }
}
