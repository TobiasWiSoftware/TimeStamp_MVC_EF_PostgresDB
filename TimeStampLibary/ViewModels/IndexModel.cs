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
        public List<EmployeeModel> Employees { get; set; }

        public IndexModel()
        {
            
        }
        public IndexModel(List<EmployeeModel> employees)
        {
            Employees = employees;
        }

    }
}
