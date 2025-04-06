
using System.ComponentModel.DataAnnotations;
using Demo.DataAccess.Models.EmployeeModel;
using Demo.DataAccess.Models.Shared.Enum;

namespace Demo.BusinessLogic.DataTransferObjects.EmployeeDto
{
    public class EmployeeDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        [DataType(DataType.Currency)]
        public decimal salary { get; set; }
        public bool IsActive { get; set; }
        public string? Email { get; set; }      
        public Gender empGender { get; set; }
        public EmployeeType empType { get; set; }

        public int? DepartmentId { get; set; } //FK

    }
}
