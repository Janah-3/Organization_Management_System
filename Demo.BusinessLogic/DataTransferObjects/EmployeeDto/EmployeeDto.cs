using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo.DataAccess.Models.EmployeeModel;
using Demo.DataAccess.Models.Shared.Enum;

namespace Demo.BusinessLogic.DataTransferObjects.EmployeeDto
{
    public class EmployeeDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
       
        public decimal salary { get; set; }
        public bool IsActive { get; set; }
        public string? Email { get; set; }      
        public Gender Gender { get; set; }
        public EmployeeType employeeType { get; set; }
      
    }
}
