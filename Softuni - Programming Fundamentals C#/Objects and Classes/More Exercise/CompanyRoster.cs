using System;
using System.Collections.Generic;
using System.Linq;
namespace CompanyRoster
{
    class CompanyRoster
    {
        static void Main()
        {
            List<Department> departments = new List<Department>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split();
                if (!departments.Any(d => d.Name == input[2]))
                {
                    departments.Add(new Department(input[2]));
                }

                departments.Find(d => d.Name == input[2]).AddNewEmployee(input[0], decimal.Parse(input[1]));

            }
            Department bestDepartment = departments.OrderByDescending(d => d.TotalSalaries / d.Employees.Count()).First();

            Console.WriteLine($"Highest Average Salary: {bestDepartment.Name}");
            foreach (var employee in bestDepartment.Employees.OrderByDescending(e => e.Salary))
            {
                Console.WriteLine($"{employee.Name} {employee.Salary:F2}");
            }

        }
    }

    class Employee
    {
        public string Name { get; set; }
        public decimal Salary { get; set; }

        public Employee(string name, decimal salary)
        {
            this.Name = name;
            this.Salary = salary;
        }
    }

    class Department
    {
        public string Name { get; set; }
        public List<Employee> Employees { get; set; } = new List<Employee>();
        public decimal TotalSalaries { get; set; }

        public void AddNewEmployee(string empName, decimal empSalary)
        {
            this.TotalSalaries += empSalary;

            this.Employees.Add(new Employee(empName, empSalary));
        }

        public Department(string departmentName)
        {
            this.Name = departmentName;
        }
    }
}