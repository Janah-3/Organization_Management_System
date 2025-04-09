using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo.DataAccess.Data.contexts;
using Demo.DataAccess.Models.DepartmentModel;
using Demo.DataAccess.Repositories.interfaces;

namespace Demo.DataAccess.Repositories.classes
{
    public class UnitOfWork : IUnitOfWork
    {
        private Lazy<IDepartmentRepo> _DepartmentRepo { get; set; }
        private Lazy<IEmployeeRepository> _EmployeeRepo { get; set; }
        private AppDbContext _Dbcontext { get; }

        public UnitOfWork(IDepartmentRepo departmentRepo, IEmployeeRepository employeeRepository, AppDbContext dbcontext)
        {
            _DepartmentRepo = new Lazy<IDepartmentRepo>(() => new DepartmentRepo(dbcontext));
            _EmployeeRepo = new Lazy<IEmployeeRepository>(() => new EmployeeRepo(dbcontext));
            this._Dbcontext = dbcontext;
        }



        public IEmployeeRepository EmployeeRepository => _EmployeeRepo.Value;

        public IDepartmentRepo DepartmentRepository => _DepartmentRepo.Value;

        public int SaveChanges() => _Dbcontext.SaveChanges();
    }
}