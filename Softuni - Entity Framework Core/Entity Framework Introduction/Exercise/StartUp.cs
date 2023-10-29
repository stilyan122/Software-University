using Microsoft.EntityFrameworkCore;
using SoftUni.Data;
using SoftUni.Models;
using System.Reflection;
using System.Text;
using System.Threading.Channels;

namespace SoftUni
{
    public class StartUp
    {
        static void Main()
        {
            // We can check the correctness of our methods here -
            // in the Main()
            var context = new SoftUniContext();
            //TODO: ...
        }

        //--03.
        public static string GetEmployeesFullInformation(SoftUniContext context)
        {
            StringBuilder builder = new StringBuilder();

            var employees = context.Employees.OrderBy(e => e.EmployeeId);
            foreach (Employee employee in employees)
            {
                builder.AppendLine($"{employee.FirstName} " +
                    $"{employee.LastName} {employee.MiddleName} " +
                    $"{employee.JobTitle} {employee.Salary:f2}");
            }

            return builder.ToString().Trim();
        }
       
        //--04.
        public static string GetEmployeesWithSalaryOver50000(SoftUniContext context)
        {
            var employees = context.Employees
                .Where(e => e.Salary > 50000)
                .OrderBy(e => e.FirstName)
                .Select(e => new
                {
                    e.FirstName,
                    e.Salary
                }).ToList();
            string result =
                string.Join(Environment.NewLine, 
                employees.Select(e => $"{e.FirstName} - {e.Salary}"
            ));
            return result;
        }
        
        //--05.
        public static string GetEmployeesFromResearchAndDevelopment(SoftUniContext context)
        {
            var employees = context.Employees
                .Include(x => x.Department)
                .Where(x => 
                x.Department.Name == "Research and Development")
                .OrderBy(e => e.Salary)
                .ThenByDescending(e => e.FirstName)
                .Select(e => new
                {
                    e.FirstName,
                    e.LastName,
                    e.Department.Name,
                    e.Salary
                })
                .ToList();

            string result = string.Join
                (Environment.NewLine,
                employees.Select(e => $"{e.FirstName} {e.LastName} from " +
                $"{e.Name} - ${e.Salary:f2}"));
            return result.Trim();
        }
        
        //--06.
        public static string AddNewAddressToEmployee(SoftUniContext context)
        {
            var address = new Address
            {
                AddressText = "Vitoshka 15",
                TownId = 4
            };

            var employees = context.Employees.ToList();

            employees
                .FirstOrDefault(x => x.LastName == "Nakov")
                .Address = address;

            context.SaveChanges();

            var outputEmployees =
                context.Employees
                .Include(e => e.Address)
                .OrderByDescending(e => e.Address.AddressId)
                .Take(10)
                .Select(e => new
                {
                    e.Address.AddressText
                })
                .ToList();

            string result = string.Join(Environment.NewLine,
                outputEmployees
                .Select(e => e.AddressText));

            return result.Trim();
        }
        
        //--07.
        public static string GetEmployeesInPeriod(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();
            var employees =
                context.Employees
                .Include(e => e.EmployeesProjects)
                .Include(e => e.Manager)
                .Take(10)
                .Select(e => new
                {
                    e.Manager,
                    e.FirstName,
                    e.LastName,
                    e.EmployeeId
                })
                .ToList();

            foreach (var employee in employees)
            {
                sb.AppendLine($"{employee.FirstName} {employee.LastName} " +
                    $"- Manager: {employee.Manager.FirstName} " +
                    $"{employee.Manager.LastName}");

                var projects =
                    context.EmployeesProjects
                    .Where(ep => ep.EmployeeId == employee.EmployeeId)
                    .Include(ep => ep.Project)
                    .Select(ep => new
                    {
                        ep.Project
                    })
                    .ToList();

                List<Project> projectsInPeriod = new List<Project>();
                foreach (var project in projects)
                {
                    if (project.Project.StartDate.Year >= 2001 
                        && project.Project.StartDate.Year <= 2003)
                    {
                        projectsInPeriod.Add(project.Project);
                    }
                }
                projectsInPeriod
                    .ForEach(p =>
                    {
                            if (p.EndDate != null)
                                sb.AppendLine($"--{p.Name} - " +
                                    $"{p.StartDate.ToString("M/d/yyyy h:mm:ss tt")} - " +
                                    $"{p.EndDate?.ToString("M/d/yyyy h:mm:ss tt")}");
                            else
                                sb.AppendLine($"--{p.Name} - " +
                                    $"{p.StartDate.ToString("M/d/yyyy h:mm:ss tt")} " +
                                    $"- not finished");
                    });

            }
            return sb.ToString().Trim();
        }

        //--08.
        public static string GetAddressesByTown(SoftUniContext context)
        {
            var addresses =
                context.Addresses
                .Include(a => a.Employees)
                .Include(a => a.Town)
                .OrderByDescending(a => a.Employees.Count)
                .ThenBy(a => a.Town.Name)
                .ThenBy(a => a.AddressText)
                .Take(10)
                .Select(a => new {
                    a.AddressText,
                    a.Town.Name,
                    a.Employees.Count
                })
                .ToList();
            string result = string.Join(Environment.NewLine,
                addresses.Select
                (a => $"{a.AddressText}, {a.Name} - {a.Count} employees"));
            return result;
        }

        //--09.
        public static string GetEmployee147(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();
            var employees = context
                .Employees
                .Include(x => x.EmployeesProjects)
                .Where(x => x.EmployeeId == 147)
                .Select(e => new
                {
                    e.FirstName,
                    e.LastName,
                    e.JobTitle,
                    e.EmployeesProjects,
                    e.EmployeeId
                })
                .ToList();
            foreach (var employee in employees)
            {
                sb.AppendLine($"{employee.FirstName} " +
                    $"{employee.LastName} - {employee.JobTitle}");
                
                context
                    .EmployeesProjects
                    .Where(x => x.EmployeeId == employee.EmployeeId)
                    .Include(x => x.Project)
                    .Select(x => new
                    {
                        x.Project.Name
                    })
                    .OrderBy(x => x.Name)
                    .ToList()
                    .ForEach(ep =>
                    {
                        sb.AppendLine(ep.Name);
                    });
            }
            return sb.ToString().Trim();
        }

        //--10.
        public static string GetDepartmentsWithMoreThan5Employees(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();
            var departments = 
                context.Departments
                .Include(d => d.Employees)
                .Include(d => d.Manager)
                .Where(d => d.Employees.Count > 5)
                .OrderBy(d => d.Employees.Count)
                .ThenBy(d => d.Name)
                .Select(d => new
                {
                    d.Name,
                    d.Manager.FirstName,
                    d.Manager.LastName,
                    d.Employees
                });

            foreach (var department in departments)
            {
                sb.AppendLine($"{department.Name} - " +
                    $"{department.FirstName} " +
                    $"{department.LastName}");

                var employees =
                    department.Employees
                    .OrderBy(e => e.FirstName)
                    .ThenBy(e => e.LastName);

                foreach (var employee in employees)
                {
                    sb.AppendLine($"{employee.FirstName} " +
                        $"{employee.LastName} - {employee.JobTitle}");
                }
            }
            return sb.ToString().Trim();
        }

        //--11.
        public static string GetLatestProjects(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            var latestProjects =
                context.Projects
                .OrderByDescending(p => p.StartDate)
                .Take(10)
                .Select(p => new
                {
                    p.Name,
                    p.Description,
                    p.StartDate
                })
                .OrderBy(p => p.Name)
                .ToList();

            latestProjects.ForEach(p =>
            {
                sb.AppendLine(p.Name);
                sb.AppendLine(p.Description);
                sb.AppendLine(p.StartDate.ToString("M/d/yyyy h:mm:ss tt"));
            });

            return sb.ToString().Trim();
        }

        //--12.
        public static string IncreaseSalaries(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            var employees =
                context.Employees
                .Include(e => e.Department)
                .Where(e => e.Department.Name == "Engineering"
                 || e.Department.Name == "Tool Design"
                 || e.Department.Name == "Marketing"
                 || e.Department.Name == "Information Services")
                .ToList();

            employees.ForEach(e =>
            {
                e.Salary += (decimal)0.12 * e.Salary;
            });

            context.SaveChanges();

            employees
            .OrderBy(e => e.FirstName)
            .ThenBy(e => e.LastName)
            .ToList()
            .ForEach(employee =>
            {
                sb.AppendLine($"{employee.FirstName} " +
                    $"{employee.LastName} (${employee.Salary:f2})");
            });

            return sb.ToString().Trim();
        }

        //--13.
        public static string GetEmployeesByFirstNameStartingWithSa(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            var employees =
                context.Employees
                .Where(e => e.FirstName
                .Substring(0, 2).ToLower() == "sa")
                .Select(e => new
                {
                    e.FirstName,
                    e.LastName,
                    e.JobTitle,
                    e.Salary
                })
                .OrderBy(e => e.FirstName)
                .ThenBy(e => e.LastName)
                .ToList();

            employees.ForEach(e =>
            {
                sb.AppendLine($"{e.FirstName} {e.LastName} - " +
                    $"{e.JobTitle} - (${e.Salary:f2})");
            });

            return sb.ToString().Trim();
        }

        //--14.
        public static string DeleteProjectById(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            var project = context.Projects.Find(2);
            var ep = context.EmployeesProjects
                .Where(ep => ep.ProjectId == 2);

            context.EmployeesProjects.RemoveRange(ep);
            context.Projects.Remove(project);
            context.SaveChanges();

            context.Projects.ToList().ForEach(e =>
            {
                sb.AppendLine(e.Name);
            });

            return sb.ToString().Trim();
        }

        //--15.
        public static string RemoveTown(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            context.Employees
            .Include(e => e.Address)
            .Include(e => e.Address.Town)
            .ToList().ForEach(x =>
            {
                if (x.Address?.Town?.Name == "Seattle")
                {
                    x.AddressId = null;
                }
            });

            context.SaveChanges();

            var addresses =
                context.Addresses
                .Include(a => a.Town)
                .ToList()
                .Where(x => x.Town?.Name == "Seattle");

            int removedCount = addresses.ToList().Count;

            context.Addresses
                .RemoveRange(addresses);

            context.SaveChanges();

            var townToRemove = 
                context.Towns
                .ToList()
                .Find(x => x.Name == "Seattle");

            context.Towns.Remove(townToRemove);

            context.SaveChanges();

            sb.AppendLine($"{removedCount} addresses " +
                $"in Seattle were deleted");

            return sb.ToString().Trim();
        }
    }
}