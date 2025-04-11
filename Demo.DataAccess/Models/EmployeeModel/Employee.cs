using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo.DataAccess.Models.DepartmentModel;
using Demo.DataAccess.Models.Shared;
using Demo.DataAccess.Models.Shared.Enum;

namespace Demo.DataAccess.Models.EmployeeModel
{
    public class Employee :BaseEntity
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string? Address { get; set; }
        public decimal Salary { get; set; }
        public bool IsActive { get; set; }
        public string? Email { get; set; }  
        public string? PhoneNumber { get; set; }
        public Gender Gender { get; set; }   
        public DateTime HiringDate { get; set; }
        public EmployeeType employeeType { get; set; }

        public int? DepartmentId { get; set; } //FK
    public  virtual   Department? Department { get; set; } //navigation property

        public string?  ImageName { get; set; }

    }
}
