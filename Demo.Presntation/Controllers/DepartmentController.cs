using Demo.BusinessLogic.DataTransferObjects;
using Demo.BusinessLogic.Services;
using Demo.Presntation.ViewModels.Department;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.Blazor;

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


        #region create department
        [HttpGet]
        public IActionResult Create() => View();

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
        #endregion

        #region details of department
        [HttpGet]
        public IActionResult Details(int? id)
        {
            if (!id.HasValue)
            {
                return BadRequest();
            }
            else
            {
                var department = _departmentService.GetDepartmentById(id.Value);
                if (department == null) return NotFound();
                return View(department);
            }
        }

        #endregion

        #region edit department
        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (!id.HasValue) return BadRequest();
            var department = _departmentService.GetDepartmentById(id.Value);
            if (department == null) return NotFound();
            var departmentViewModel = new DepartmentEditViewModel()
            {
                Code = department.Code,
                Name = department.Name,
                Description = department.Description,
                DateofCreation=department.CreatedOn

            };

            return View(departmentViewModel);
        }


        [HttpPost]
        public IActionResult Edit(int id ,DepartmentEditViewModel viewModel)
        {
            

            if(ModelState.IsValid) {

                try
                {
                    var updatedDepartment = new UpdatedDepartmentDto()
                    {
                        Id = id,
                        Code = viewModel.Code,
                        Name = viewModel.Name,
                        description = viewModel.Description,
                        DateOfCreation = viewModel.DateofCreation
                    };
                    int result = _departmentService.UpdateDepartment(updatedDepartment);
                    if (result > 0)
                        return RedirectToAction(nameof(Index));
                    else
                    {
                        ModelState.AddModelError(string.Empty, "department is not updated");
                        
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
                        return View("errorView", ex);

                    }

                }
                }
            return View(viewModel);
        }

        #endregion

        #region delete department

        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if(!id.HasValue) return BadRequest();
            var department = _departmentService.GetDepartmentById(id.Value);
            if (department == null) return NotFound();
            return View(department);

        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            if (id ==0 ) return BadRequest();

            try
            {
                bool Deleted = _departmentService.DeleteDepartment(id);

                if (Deleted) return RedirectToAction(nameof(Index));

                else
                {
                    ModelState.AddModelError(string.Empty, "department is not deleted");
                    return RedirectToAction(nameof(Delete) , new {id });
                }
            }
            catch (Exception ex)
            {
                if (_environment.IsDevelopment())
                {
                    //1.development => log error in console and return same view with error message
                    ModelState.AddModelError(string.Empty, ex.Message);
                    RedirectToAction(nameof(Index));


                }
                else
                {
                    //2.deployment => log error in file or table in the database and return views
                    _logger.LogError(ex.Message);
                    return View("errorView" , ex);
                }
               
            }
          return RedirectToAction(nameof(Index));
        }


        #endregion

    }
}
