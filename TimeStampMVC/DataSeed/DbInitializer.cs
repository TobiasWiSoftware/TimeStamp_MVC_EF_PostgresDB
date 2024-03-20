using TimeStampLibary.Models;
using TimeStampMVC.Data;

namespace TimeStampMVC.DataSeed
{
    public static class DbInitializer
    {
        public static void Initialize(ApplicationDbContext context)
        {
            //bool existing = context.Database.EnsureCreated();

            // Look for any employees.
            if (context.Employees.Any())
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
                context.Employees.Add(e);
            }
            context.SaveChanges();

            List<CardModel> cards = new List<CardModel>
            {
                new CardModel(DateTime.UtcNow, DateTime.UtcNow.AddYears(1), true, true, true, employees[1]),
                new CardModel(DateTime.UtcNow, DateTime.UtcNow.AddYears(1), true, false, true, employees[2]),
                new CardModel(DateTime.UtcNow, DateTime.UtcNow.AddYears(1), true, true, true, employees[3]),
                new CardModel(DateTime.UtcNow, DateTime.UtcNow.AddYears(1), true, true, false, employees[4]),
            };

            foreach (CardModel c in cards)
            {
                context.Cards.Add(c);
            }
        }
    }

}
