using System.Security;
using TimeStampLibary.Models;

namespace TimeStampMVC.Repository
{
    public interface IEmployeeRepository
    {
        Task<bool> AddEmployeeAsync(EmployeeModel employee);
        Task<IEnumerable<EmployeeModel>> GetEmployeesAsync();
        Task<EmployeeModel?> GetEmployeeAsync(int id);
        Task UpdateEmployeeAsync(EmployeeModel employee);
        Task DeleteEmployeeAsync(int id);
    }
}
