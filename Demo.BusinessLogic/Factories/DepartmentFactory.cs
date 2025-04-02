using Demo.BusinessLogic.DataTransferObjects.Department;
using Demo.DataAccess.Models.DepartmentModel;

namespace Demo.BusinessLogic.Factories
{
    //it is static because we don't want to create an instance of this class and will make extension methods
    public static class DepartmentFactory
    {
        public static DepartmentDto ToDepartmentDto(this Department department)
        {
            return new DepartmentDto
            {
                DeptId = department.Id,
                Name = department.Name,
                Code = department.Code,
                Description = department.Description,
                DateofCreation = DateOnly.FromDateTime(department.CreatedOn)
            };

        }

        public static DepartmentDetailsDto ToDepartmentDetailsDto(this Department department)
        {
            return new DepartmentDetailsDto
            {
                Id = department.Id,
                Name = department.Name,
                Code = department.Code,
                Description = department.Description,
                CreatedOn = DateOnly.FromDateTime(department.CreatedOn)
            };
        }


        public static Department ToEntity(this CreatedDepartmentDto departmentDto) {

            return new Department()
            {
                Name = departmentDto.Name,
                Code = departmentDto.Code,
                Description = departmentDto.description,
                CreatedOn = departmentDto.DateOfCreation.ToDateTime(new TimeOnly())
            };
        }

        public static Department ToEntity(this UpdatedDepartmentDto departmentDto)
        {

            return new Department()
            {
                Id= departmentDto.Id,
                Name = departmentDto.Name,
                Code = departmentDto.Code,
                Description = departmentDto.description,
                CreatedOn = departmentDto.DateOfCreation.ToDateTime(new TimeOnly())
            };
        }

    }
}
