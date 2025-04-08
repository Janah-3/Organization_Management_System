using Demo.BusinessLogic.Factories;
using Demo.DataAccess.Repositories.interfaces;
using Demo.BusinessLogic.DataTransferObjects.Department;
using Demo.DataAccess.Repositories;

namespace Demo.BusinessLogic.Services
{
    public class DepartmentService(IUnitOfWork unitOfWork) : IDepartmentService
    {

        public IEnumerable<DepartmentDto>? GetAllDepartments()
        {
            var departments = unitOfWork.DepartmentRepository.GetAll();


            //manual mapping or coverting the department into departmentDto
            // var departmentToReturn = departments.Select(d => new DepartmentDto
            //{
            //    DeptId = d.Id,
            //    Name = d.Name,
            //    Code = d.Code,
            //    Description = d.Description,
            //    DateofCreation = DateOnly.FromDateTime(d.CreatedOn)
            //});
            // return departmentToReturn;

            return departments.Select(d => d.ToDepartmentDto());
        }


        //get department by id 
        public DepartmentDetailsDto? GetDepartmentById(int id)
        {
            var department = unitOfWork.DepartmentRepository.GetById(id);

            //manual mapping
            //auto mapping //most used for big projects
            //constructor mapping
            //extension methods 
            return department is null ? null : department.ToDepartmentDetailsDto();


        }

        //create new department
        public int AddDepartment(CreatedDepartmentDto departmentDto)
        {
            var department = departmentDto.ToEntity();
             unitOfWork.DepartmentRepository.Add(department);
           return  unitOfWork.SaveChanges();

        }

        //update department
        public int UpdateDepartment(UpdatedDepartmentDto departmentDto)
        {
            unitOfWork.DepartmentRepository.Update(departmentDto.ToEntity());
            return unitOfWork.SaveChanges();
        }

        //delete Department 
        public bool DeleteDepartment(int id)
        {
            var Dept = unitOfWork.DepartmentRepository.GetById(id);
            if (Dept is null) return false;

            else
            {
                  unitOfWork.DepartmentRepository.remove(Dept);
                int result = unitOfWork.SaveChanges();
                if (result > 0) return true;
                else return false; ;
            }
        }




    }
}
