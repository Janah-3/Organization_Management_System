
using Demo.DataAccess.Data.contexts;
using Demo.DataAccess.Models.DepartmentModel;

namespace Demo.DataAccess.Repositories
{
    //primart constructor .net8 c#12
    public class DepartmentRepo(AppDbContext dbContext) : IDepartmentRepo
    {
        private readonly AppDbContext _dbContext = dbContext;

        //CRUD
        //get all departments
        public IEnumerable<Department> GetAll(bool WithTracking = false)
        {
            if (WithTracking)
                return _dbContext.Departments.ToList();
            else
                return _dbContext.Departments.AsNoTracking().ToList();

        }

        //get department by id
        public Department GetById(int id) => _dbContext.Departments.Find(id);

        //update department
        public int Update(Department department)
        {
            _dbContext.Departments.Update(department);
            return _dbContext.SaveChanges();
        }

        //delete department
        public int remove(Department department)
        {

            _dbContext.Departments.Remove(department);
            return _dbContext.SaveChanges();
        }

        //add department(insert)
        public int Add(Department department)
        {
            _dbContext.Departments.Add(department);
            return _dbContext.SaveChanges();

        }
    }
}
