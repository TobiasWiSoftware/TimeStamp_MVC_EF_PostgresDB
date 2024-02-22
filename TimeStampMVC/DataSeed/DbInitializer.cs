using TimeStampLibary.Models;
using TimeStampMVC.Data;

namespace TimeStampMVC.DataSeed
{
    public static class DbInitializer
    {
        public static void Initialize(ApplicationDbContext context)
        {
            context.Database.EnsureCreated();

            // Look for any employees.
            if (context.Employee.Any())
            {
                return;   // DB has been seeded
            }

            var employees = new EmployeeModel[]
            {
                new EmployeeModel{GivenName="Max", Surname="Mustermann", Email="max.mustermann@muster.de"},
                new EmployeeModel{GivenName="John", Surname="Doe", Email="john.doe@example.com"},
                new EmployeeModel{GivenName="Jane", Surname="Smith", Email="jane.smith@example.com"},
                new EmployeeModel{GivenName="Emily", Surname="Johnson", Email="emily.johnson@example.com"},
                new EmployeeModel{GivenName="Michael", Surname="Brown", Email="michael.brown@example.com"}
            };




            foreach (EmployeeModel e in employees)
            {
                context.Employee.Add(e);
            }
            context.SaveChanges();
        }
    }

}
