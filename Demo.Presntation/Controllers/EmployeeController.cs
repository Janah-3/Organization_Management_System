using Demo.BusinessLogic.DataTransferObjects.EmployeeDto;
using Demo.BusinessLogic.Services;
using Demo.DataAccess.Models.Shared.Enum;
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

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if(!id.HasValue) return BadRequest();

            var employee = _employeeService.GetEmployeeById(id.Value);
            if (employee is null) return NotFound();

            var employeeDto = new UpdatedEmployeeDto()
            {
                Id = employee.Id,
                Name = employee.Name,
                salary = employee.salary,
                Address = employee.Address,
                Age = employee.Age,
                PhoneNumber = employee.PhoneNumber,
                IsActive = employee.IsActive,
                HiringDate = employee.HiringDate,

            };

            return View(employeeDto);

        }

        [HttpPost]
        public IActionResult Edit([FromRoute]int? id ,UpdatedEmployeeDto employeeDto)
        {

            if (!id.HasValue || id!= employeeDto.Id) return BadRequest();


            if (ModelState.IsValid)
            {
                try
                {
                    int result = _employeeService.UpdateEmployee(employeeDto);
                    if (result > 0)
                        return RedirectToAction("Index");
                    else
                        ModelState.AddModelError("", "Failed to update employee.");
                }
                catch (Exception ex)
                {
                    if (Environment.IsDevelopment())
                    {
                        ModelState.AddModelError("", ex.Message);
                    }
                    else
                    {
                        ModelState.AddModelError("", "An error occurred while updating the employee.");
                        Logger.LogError(ex, "An error occurred while updating the employee.");
                    }
                }
            }
            return View(employeeDto);
        }


    }
}
