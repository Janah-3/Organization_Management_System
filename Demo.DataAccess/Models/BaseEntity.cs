using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.DataAccess.Models
{
    public class BaseEntity
    {
        public int Id { get; set; } //pk
        public int CreatedBy { get; set; } //user_id
        public DateTime CreatedOn { get; set; } //creation_date
        public int LastModifiedBy { get; set; } //modified_by
        public DateTime? LastModifiedOn { get; set; } //modifications_date
        public bool IsDeleted { get; set; } //soft delete

    }
}
