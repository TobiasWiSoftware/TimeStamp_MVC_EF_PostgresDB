using Microsoft.AspNetCore.Mvc;
using TimeStampLibary.Models;
using TimeStampMVC.Services;
using TimeStampLibary.ViewModels;

namespace TimeStampMVC.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService _employeeService;
        public EmployeeController(IEmployeeService eservice)
        {
            _employeeService = eservice;
        }

        public IActionResult Index()
        {
            var model = new IndexModel();
            return View(model);
        }

        public async Task<ActionResult> AddEmployee(IndexModel em)
        {
            bool res = await _employeeService.AddEmployee(em.NewEmployee);

            return Redirect("/Home/Index");
        }

        public async Task<ActionResult<List<EmployeeModel>>> GetEmployees()
        {
            var res = await _employeeService.GetEmployees();
            return Redirect("/Home/Index");
        }
    }
}
