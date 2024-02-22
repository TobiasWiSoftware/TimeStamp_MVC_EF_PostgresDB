using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TimeStampLibary.Models;
using TimeStampLibary.ViewModels;
using TimeStampMVC.Services;


namespace TimeStampMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IEmployeeService _employeeService;

        public HomeController(ILogger<HomeController> logger, IEmployeeService employeeService)
        {
            _logger = logger;
            _employeeService = employeeService;
        }

        public async Task<IActionResult> Index()
        {
            IEnumerable<EmployeeModel> employees = await _employeeService.GetEmployees();
            var model = new IndexModel(employees.ToList());
            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
