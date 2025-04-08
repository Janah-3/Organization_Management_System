
using Demo.DataAccess.Repositories.interfaces;

namespace Demo.DataAccess.Repositories
{
    public interface IUnitOfWork
    {
        public IEmployeeRepository EmployeeRepository { get; }
        public IDepartmentRepo DepartmentRepository { get; }

        public int SaveChanges();
    }
}
