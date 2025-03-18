namespace Demo.DataAccess.Data.configrations
{
    public class DepartmentConfiguration : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            builder.Property(d => d.Id).UseIdentityColumn(10, 10);
            builder.Property(d => d.Name).HasColumnType("varchar(20)");
            builder.Property(d => d.Code).HasColumnType("varchar(20)");
            builder.Property(d => d.CreatedOn).HasDefaultValueSql("getdate()");
            builder.Property(d => d.LastModifiedOn).HasComputedColumnSql("getdate()");
        }
    }


}
