
using Demo.BusinessLogic.DataTransferObjects.EmployeeDto;
using Demo.DataAccess.Models.EmployeeModel;

namespace Demo.BusinessLogic.Factories
{

    public static class EmployeeFactory
    {
        public static EmployeeDto ToEmployeeDto(this Employee Employee)
        {
            return new EmployeeDto
            {
                Id = Employee.Id,
                Name = Employee.Name,
                Age = Employee.Age,
                IsActive = Employee.IsActive,
                salary = Employee.Salary,
                Email = Employee.Email,
                employeeType = Employee.employeeType

            };

        }

        public static EmployeeDetailsDto ToEmployeeDetailsDto(this Employee Employee)
        {
            return new EmployeeDetailsDto
            {
                Id = Employee.Id,
                Name = Employee.Name,
                Age = Employee.Age,
                IsActive = Employee.IsActive,
                salary = Employee.Salary,
                Email = Employee.Email,
                PhoneNumber = Employee.PhoneNumber,
                HiringDate = Employee.HiringDate,
                Gender = Employee.Gender,
                employeeType = Employee.employeeType
            };
        }


        public static Employee ToEntity(this CreateEmployeeDto EmployeeDto)
        {

            return new Employee()
            {

                Name = EmployeeDto.Name,
                Age = EmployeeDto.Age,
                IsActive = EmployeeDto.IsActive,
                Salary = EmployeeDto.salary,
                Email = EmployeeDto.Email,
                PhoneNumber = EmployeeDto.PhoneNumber,
                HiringDate = EmployeeDto.HiringDate,
                Gender = EmployeeDto.Gender,
                employeeType = EmployeeDto.employeeType



            };
        }

        public static Employee ToEntity(this UpdatedEmployeeDto EmployeeDto)
        {

            return new Employee()
            {
                Id = EmployeeDto.Id,
                Name = EmployeeDto.Name,
                IsActive = EmployeeDto.IsActive,
                Salary = EmployeeDto.salary,
                Email = EmployeeDto.Email,
                PhoneNumber = EmployeeDto.PhoneNumber,
                HiringDate = EmployeeDto.HiringDate,
                Gender = EmployeeDto.Gender,
                employeeType = EmployeeDto.employeeType,
                CreatedBy = EmployeeDto.CreatedBy,
                LastModifiedBy = EmployeeDto.LastModifiedBy,


            };
        }
    }
}
