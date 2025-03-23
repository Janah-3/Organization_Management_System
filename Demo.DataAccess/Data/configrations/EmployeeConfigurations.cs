using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo.DataAccess.Models.Shared.Enum;

namespace Demo.DataAccess.Data.configrations
{
    public class EmployeeConfigurations : BaseEntityConfigurations<Employee>, IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.Property(e => e.Name).HasColumnType("varchar(50)");
            builder.Property(e => e.Address).HasColumnType("varchar(15)");
            builder.Property(e => e.Salary).HasColumnType("decimal(10)");
            builder.Property(e => e.Gender).HasConversion((EmpGender) => EmpGender.ToString(), (gender) =>(Gender) Enum.Parse(typeof(Gender) , gender));
            builder.Property(E => E.employeeType)
                .HasConversion((EmpType) => EmpType.ToString()
                ,(_type) => (EmployeeType)Enum.Parse(typeof(EmployeeType),_type));

            base.Configure(builder);
        }
    }
}
