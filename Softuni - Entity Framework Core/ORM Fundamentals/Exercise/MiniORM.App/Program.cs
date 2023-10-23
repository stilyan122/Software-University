using MiniORM.App.Data.Entities;
namespace MiniORM.App
{
    public class Program
    {
        static void Main()
        {
            var connectionString =
                "Server=.;Database=MiniORM;Integrated Security=True;" +
                "Encrypt=False;";
            var context = new SoftUniDbContext(connectionString);
            context.Employees.Add(new Employee
            {
                FirstName = "Gosho",
                LastName = "Inserted",
                DepartmentId = context.Departments.First().Id,
                IsEmployed = true
            });
            var employee = context.Employees.Last();
            employee.FirstName = "Modified";
            context.SaveChanges();
        }
    }
}