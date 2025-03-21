
using Demo.DataAccess.Repositories;
using Demo.BusinessLogic.Factories;
using Demo.BusinessLogic.DataTransferObjects;

namespace Demo.BusinessLogic.Services
{
    public class DepartmentService(IDepartmentRepo _departmentRepo) : IDepartmentService
    {

        public IEnumerable<DepartmentDto>? GetAllDepartments()
        {
            var departments = _departmentRepo.GetAll();


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
            var department = _departmentRepo.GetById(id);

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
            return _departmentRepo.Add(department);
        }

        //update department
        public int UpdateDepartment(UpdatedDepartmentDto departmentDto) => _departmentRepo.Update(departmentDto.ToEntity());

        //delete Department 
        public bool DeleteDepartment(int id)
        {
            var Dept = _departmentRepo.GetById(id);
            if (Dept is null) return false;

            else
            {
                int result = _departmentRepo.remove(Dept);
                return result > 0 ? true : false;
            }
        }




    }
}
