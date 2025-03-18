
using Demo.DataAccess.Data.contexts;

namespace Demo.DataAccess.Repositories
{
    //primart constructor .net8 c#12
    class DepartmentRepo(AppDbContext dbContext)
    {
        private readonly AppDbContext _dbContext = dbContext;

        //CRUD
        //get all departments
        //get department by id
        public Department GetById(int id)
        {
            var department = _dbContext.Departments.Find(id);
            return department;
        }
        //update department
        //delete department
        //add department(insert)
    }
}
