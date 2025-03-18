using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Demo.DataAccess.Data.contexts
{
    
    public class AppDbContext: DbContext
    {
        public DbSet<Department> Departments { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        { 
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //   optionsBuilder.UseSqlServer("Server=.;Database=DemoDb;Trusted_Connection=True;");
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());//i can use this line of code to apply all configurations in the assembly when the dbcontext class and the dataAccess are in the same project 
           // modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);//i can use this line of code to apply all configurations in the assembly when the dbcontext class and the dataAccess are in the different projects
        }


    }
}
