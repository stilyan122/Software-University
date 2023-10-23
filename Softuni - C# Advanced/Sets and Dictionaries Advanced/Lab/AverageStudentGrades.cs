using System;
using System.Collections.Generic;
using System.Linq;

namespace AverageStudentGrades
{
    class AverageStudentGrades
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<string, List<decimal>> report = new Dictionary<string, List<decimal>>();
            for (int i = 0; i < n; i++)
            {
                string[] info = Console.ReadLine().Split();
                string name = info[0];
                decimal grade = decimal.Parse(info[1]);
                if (!report.ContainsKey(name))
                {
                    report.Add(name, new List<decimal>() { grade });
                }
                else
                {
                    report[name].Add(grade);
                }
            }
            foreach (var student in report)
            {
                Console.Write($"{student.Key} -> ");
                foreach (var grade in student.Value)
                {
                    Console.Write($"{grade:f2} ");
                }
                Console.WriteLine($"(avg: {student.Value.Average():f2})");
            }
        }
    }
}
