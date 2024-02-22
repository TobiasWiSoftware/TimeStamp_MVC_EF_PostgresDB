using System.Security;
using TimeStampLibary.Models;
using TimeStampMVC.Repository;

namespace TimeStampMVC.Services
{
    public class EmployeeService : IEmployeeService
    {
        public readonly IEmployeeRepository _employeeRepository;

        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task<bool> AddEmployee(EmployeeModel em)
        {
            return await _employeeRepository.AddEmployeeAsync(em);
        }
        public async Task<IEnumerable<EmployeeModel>> GetEmployees()
        {
            return await _employeeRepository.GetEmployeesAsync();
        }
    }
}
