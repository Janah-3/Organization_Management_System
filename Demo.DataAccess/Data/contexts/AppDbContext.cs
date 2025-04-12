
using System.Reflection;
using Demo.DataAccess.Models.DepartmentModel;
using Demo.DataAccess.Models.IdentityModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Demo.DataAccess.Data.contexts
{

    public class AppDbContext(DbContextOptions<AppDbContext> options) : IdentityDbContext<ApplicationUser>(options)
    {
        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }

       public  DbSet<ApplicationUser> users { get; set; }
        public DbSet<IdentityRole> roles { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //   optionsBuilder.UseSqlServer("Server=.;Database=DemoDb;Trusted_Connection=True;");
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());//i can use this line of code to apply all configurations in the assembly when the dbcontext class and the dataAccess are in the same project 
                                                                                          // modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);//i can use this line of code to apply all configurations in the assembly when the dbcontext class and the dataAccess are in the different projects

            base.OnModelCreating(modelBuilder);
        }


    }
}
