
using Demo.DataAccess.Models.DepartmentModel;

namespace Demo.DataAccess.Repositories
{
    public interface IDepartmentRepo
    {
        int Add(Department department);
        IEnumerable<Department> GetAll(bool WithTracking = false);
        Department GetById(int id);
        int remove(Department department);
        int Update(Department department);
    }
}