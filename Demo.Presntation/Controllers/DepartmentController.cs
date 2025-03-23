using Demo.BusinessLogic.DataTransferObjects;
using Demo.BusinessLogic.Services;
using Microsoft.AspNetCore.Mvc;

namespace Demo.Presntation.Controllers
{
    public class DepartmentController(IDepartmentService _departmentService , ILogger<DepartmentController> _logger , IWebHostEnvironment _environment) : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            var departments = _departmentService.GetAllDepartments();
            return View(departments);
        }


        [HttpGet]
        public IActionResult Create()=> View();

        [HttpPost]
        public IActionResult Create(CreatedDepartmentDto departmentDto)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    int result = _departmentService.AddDepartment(departmentDto);
                    if (result > 0)
                    {
                        return RedirectToAction(nameof(Index));
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, "Depaartment can't be created");
                        return View();
                    }

                }
                catch (Exception ex)
                {
                    if (_environment.IsDevelopment())
                    {
                        //1.development => log error in console and return same view with error message
                        ModelState.AddModelError(string.Empty, ex.Message);


                    }
                    else
                    {
                        //2.deployment => log error in file or table in the database and return views
                        _logger.LogError(ex.Message);

                    }

                }
            }

            return View(departmentDto);
        }


    }
}
