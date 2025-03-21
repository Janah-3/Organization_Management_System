using System;
using System.Collections.Generic;


namespace Demo.BusinessLogic.DataTransferObjects
{
    public class DepartmentDetailsDto
    {
        //constructror - based mapping  
        //public DepartmentDetailsDto(Department department)
        //{
        //    Id = department.Id;
        //    Name = department.Name;
        //    CreatedOn = DateOnly.FromDateTime(department.CreatedOn);
        //}
        public int Id { get; set; } //pk
        public int CreatedBy { get; set; } //user_id
        public DateOnly CreatedOn { get; set; } //creation_date
        public int LastModifiedBy { get; set; } //modified_by
        public DateOnly LastModifiedOn { get; set; } //modifications_date
        public bool IsDeleted { get; set; } //soft delete

        public string Name { get; set; } = string.Empty;
        public string Code { get; set; } = string.Empty;
        public string? Description { get; set; }
    }
}
