using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeStampLibary.Models;

namespace TimeStampLibary.ViewModels
{
    public class IndexModel
    {
        public EmployeeModel NewEmployee { get; set; } = new();
        public CardModel NewCard { get; set; }
        public List<EmployeeModel> Employees { get; set; } = new();

        public IndexModel()
        {
            NewCard = new(DateTime.UtcNow, DateTime.UtcNow.AddYears(1), true, true, true, NewEmployee);
        }
        public IndexModel(List<EmployeeModel> employees)
        {
            Employees = employees;
            NewCard = new(DateTime.UtcNow, DateTime.UtcNow.AddYears(1), true, true, true, NewEmployee);
        }

    }
}
