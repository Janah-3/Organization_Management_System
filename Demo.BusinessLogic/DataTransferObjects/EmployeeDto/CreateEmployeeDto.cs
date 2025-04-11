
using Demo.DataAccess.Models.EmployeeModel;
using Demo.DataAccess.Models.Shared.Enum;
using Microsoft.AspNetCore.Http;

namespace Demo.BusinessLogic.DataTransferObjects.EmployeeDto
{
    public class CreateEmployeeDto
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string? Address { get; set; }
        public decimal salary { get; set; }
        public bool IsActive { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public Gender Gender { get; set; }
        public DateTime HiringDate { get; set; }
        public EmployeeType employeeType { get; set; }
        public int CreatedBy { get; set; }
        public int LastModifiedBy { get; set; } 
        public int? DepartmentId { get; set; } //FK
        public IFormFile? Image { get; set; }

    }
}
