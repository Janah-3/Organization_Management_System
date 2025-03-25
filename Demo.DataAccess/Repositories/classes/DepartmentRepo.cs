using Demo.DataAccess.Data.contexts;
using Demo.DataAccess.Models.DepartmentModel;
using Demo.DataAccess.Repositories.interfaces;

namespace Demo.DataAccess.Repositories.classes
{
    //primart constructor .net8 c#12
    public class DepartmentRepo(AppDbContext dbContext) :GenericRepository<Department>( dbContext), IDepartmentRepo
    {
       
    }
}
 