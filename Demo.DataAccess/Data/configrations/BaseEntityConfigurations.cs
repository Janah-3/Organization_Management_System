using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo.DataAccess.Models.Shared;

namespace Demo.DataAccess.Data.configrations
{
    public class BaseEntityConfigurations<T> : IEntityTypeConfiguration<T> where T : BaseEntity
    {
        public void Configure(EntityTypeBuilder<T> builder)
        {
            builder.Property(d => d.CreatedOn).HasDefaultValueSql("getdate()");
            builder.Property(d => d.LastModifiedOn).HasComputedColumnSql("getdate()");
        }
    }
}
