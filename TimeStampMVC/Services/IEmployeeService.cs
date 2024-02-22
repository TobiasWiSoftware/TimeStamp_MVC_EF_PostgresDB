using TimeStampLibary.Models;

namespace TimeStampMVC.Services
{
    public interface IEmployeeService
    {
        public Task<bool> AddEmployee(EmployeeModel em);

        public Task<IEnumerable<EmployeeModel>> GetEmployees();
    }
}
