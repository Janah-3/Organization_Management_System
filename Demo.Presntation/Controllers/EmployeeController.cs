using Demo.BusinessLogic.DataTransferObjects.EmployeeDto;
using Demo.BusinessLogic.Services;
using Microsoft.AspNetCore.Mvc;

namespace Demo.Presntation.Controllers
{
    public class EmployeeController(IEmployeeService _employeeService , IWebHostEnvironment Environment , ILogger<EmployeeController> Logger) : Controller
    {
        public IActionResult Index()
        {
            var employees = _employeeService.GetAllEmployees();
            return View(employees);
        }

        [HttpGet]
        public IActionResult Create() => View();

        [HttpPost]
        public IActionResult Create(CreateEmployeeDto employeeDto)
        {
            if (ModelState.IsValid)
            {
                try
               {
                  int result =  _employeeService.AddEmployee(employeeDto);
                    if (result > 0)
                        return RedirectToAction("Index");
                    else
                        ModelState.AddModelError("", "Failed to create employee.");

                }
                catch (Exception ex)
                {
                    if(Environment.IsDevelopment())
                    {
                        ModelState.AddModelError("", ex.Message);
                    }
                    else
                    {
                        ModelState.AddModelError("", "An error occurred while creating the employee.");
                        Logger.LogError(ex, "An error occurred while creating the employee.");
                    }
                }
            }
            return View(employeeDto);
        }

        [HttpGet]
        public IActionResult Details(int? id)
        {
            if (!id.HasValue) return BadRequest();
            
                var employee = _employeeService.GetEmployeeById(id.Value);
                return employee is null ? NotFound() : View(employee);
            
        }


    }
}
