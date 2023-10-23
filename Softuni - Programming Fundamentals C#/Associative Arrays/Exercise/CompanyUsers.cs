using System;
using System.Collections.Generic;
using System.Linq;

namespace CompanyUsers
{
    class CompanyUsers
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> employees = new Dictionary<string, List<string>>();
            string[] input = Console.ReadLine().Split(" -> ");
            while (input[0]!="End")
            {
                string company = input[0];
                string employee = input[1];
                if (!employees.ContainsKey(company))
                {
                    employees.Add(company, new List<string>() { employee });
                }
                else
                {
                    if (!employees[company].Contains(employee))
                    {
                        employees[company].Add(employee);
                    }
                }
                input = Console.ReadLine().Split(" -> ");
            }
            foreach (var company in employees)
            {
                Console.WriteLine(company.Key);
                foreach (var employee in company.Value)
                {
                    Console.WriteLine("-- "+employee);
                }
            }
        }
    }
}
