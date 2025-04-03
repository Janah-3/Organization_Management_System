using Demo.BusinessLogic.Services;
using Microsoft.AspNetCore.Mvc;

namespace Demo.Presntation.Controllers
{
    public class EmployeeController(IEmployeeService _employeeService) : Controller
    {
        public IActionResult Index()
        {
            var employees = _employeeService.GetAllEmployees();
            return View(employees);
        }
    }
}
