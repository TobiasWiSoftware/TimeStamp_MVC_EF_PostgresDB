using Microsoft.EntityFrameworkCore;
using System.Security;
using TimeStampLibary.Models;
using TimeStampMVC.Data;

namespace TimeStampMVC.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly ApplicationDbContext _context;

        public EmployeeRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> AddEmployeeAsync(EmployeeModel employee)
        {
            try
            {
                _context.Employee.Add(employee);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<IEnumerable<EmployeeModel>> GetEmployeesAsync()
        {
            return await _context.Employee.ToListAsync();
        }

        public async Task<EmployeeModel?> GetEmployeeAsync(int id)
        {
            return await _context.Employee.FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<EmployeeModel?> GetEmployeeByCardIdAsync(string cardId)
        {
            return await _context.Employee.FirstOrDefaultAsync(e => e.CardNumber == cardId);
        }

        public async Task UpdateEmployeeAsync(EmployeeModel employee)
        {
            _context.Employee.Update(employee);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteEmployeeAsync(int id)
        {
            var employee = await GetEmployeeAsync(id);
            if (employee != null)
            {
                _context.Employee.Remove(employee);
                await _context.SaveChangesAsync();
            }
        }

    }
}
