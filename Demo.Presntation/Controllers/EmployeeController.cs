using Demo.BusinessLogic.DataTransferObjects.EmployeeDto;
using Demo.BusinessLogic.Services;
using Demo.DataAccess.Models.Shared.Enum;
using Demo.Presntation.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Demo.Presntation.Controllers
{
    public class EmployeeController(IEmployeeService _employeeService, IWebHostEnvironment Environment, ILogger<EmployeeController> Logger ) : Controller
    {
        public IActionResult Index()
        {
            var employees = _employeeService.GetAllEmployees();
            return View(employees);
        }

        [HttpGet]
        public IActionResult Create()
        {
          
          
            return View();
        }

        [HttpPost]
        public IActionResult Create(EmployeeViewModel employeeViewModel)
        {
            if (ModelState.IsValid)
            {
                try

                {
                    var employeeDto = new CreateEmployeeDto()
                    {
                        Name = employeeViewModel.Name,
                        Age = employeeViewModel.Age,
                        Address = employeeViewModel.Address,
                        salary = employeeViewModel.salary,
                        IsActive = employeeViewModel.IsActive,
                        Email = employeeViewModel.Email,
                        employeeType = employeeViewModel.employeeType,
                        HiringDate = employeeViewModel.HiringDate,
                        DepartmentId = employeeViewModel.DepartmentId,
                        PhoneNumber = employeeViewModel.PhoneNumber,
                        CreatedBy =employeeViewModel.CreatedBy,
                        LastModifiedBy = employeeViewModel.LastModifiedBy,


                    };
                    int result = _employeeService.AddEmployee(employeeDto);
                    if (result > 0)
                        return RedirectToAction("Index");
                    else
                        ModelState.AddModelError("", "Failed to create employee.");

                }
                catch (Exception ex)
                {
                    if (Environment.IsDevelopment())
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
            return View(employeeViewModel);
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
            if (!id.HasValue) return BadRequest();

            var employee = _employeeService.GetEmployeeById(id.Value);
            if (employee is null) return NotFound();

            var employeeViewModel = new EmployeeViewModel()
            {
             
                Name = employee.Name,
                salary = employee.salary,
                Address = employee.Address,
                Age = employee.Age,
                PhoneNumber = employee.PhoneNumber,
                IsActive = employee.IsActive,
                HiringDate = employee.HiringDate,
                CreatedBy = employee.CreatedBy,
                LastModifiedBy = employee.LastModifiedBy,
                DepartmentId= employee.DepartmentId,
               
                Gender = employee.Gender,

            };

            return View(employeeViewModel);

        }

        [HttpPost]
        public IActionResult Edit([FromRoute] int? id, EmployeeViewModel employeeViewModel)
        {
          

            if (!id.HasValue ) return BadRequest();

            var employeeDto = new UpdatedEmployeeDto()
            {
                Id = employeeViewModel.Id,
                Name = employeeViewModel.Name,
                salary = employeeViewModel.salary,
                Address = employeeViewModel.Address,
                Age = employeeViewModel.Age,
                PhoneNumber = employeeViewModel.PhoneNumber,
                IsActive = employeeViewModel.IsActive,
                HiringDate = employeeViewModel.HiringDate,
                CreatedBy = employeeViewModel.CreatedBy,
                LastModifiedBy = employeeViewModel.LastModifiedBy,
                DepartmentId = employeeViewModel.DepartmentId,
            };

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


        [HttpPost]
        public IActionResult Delete(int id)
        {
            if (id <= 0) return BadRequest();

            try
            {
                bool result = _employeeService.DeleteEmployee(id);
                if (result)
                    return RedirectToAction("Index");
                else
                    ModelState.AddModelError("", "Failed to delete employee.");
            }
            catch (Exception ex)
            {
                if (Environment.IsDevelopment())
                {
                    ModelState.AddModelError("", ex.Message);
                }
                else
                {
                    ModelState.AddModelError("", "An error occurred while deleting the employee.");
                    Logger.LogError(ex, "An error occurred while deleting the employee.");
                }
            }
            return RedirectToAction("Index");
        }
    }
}
