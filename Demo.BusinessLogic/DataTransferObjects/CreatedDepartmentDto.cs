using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.BusinessLogic.DataTransferObjects
{
    public  class CreatedDepartmentDto
    {
        [Required(ErrorMessage ="name is required !!!")]
        public string Name { get; set; } = string.Empty!;
        [Required]
        [Range(100,int.MaxValue)]
        public string Code { get; set; } = string.Empty;

        public DateOnly DateOfCreation { get; set; }
        public string description { get; set; }
    }
}
