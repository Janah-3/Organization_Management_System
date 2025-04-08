using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo.DataAccess.Data.contexts;
using Demo.DataAccess.Repositories.interfaces;

namespace Demo.DataAccess.Repositories.classes
{
    public class UnitOfWork : IUnitOfWork
    {
        private IDepartmentRepo  DepartmentRepo { get; set; }
        private IEmployeeRepository EmployeeRepo { get; set; }
        private  AppDbContext _Dbcontext { get; }

        public UnitOfWork(IDepartmentRepo departmentRepo , IEmployeeRepository employeeRepository , AppDbContext dbcontext)
        {
            DepartmentRepo = departmentRepo;
            EmployeeRepo = employeeRepository;
            this._Dbcontext = dbcontext;
        }



        public IEmployeeRepository EmployeeRepository => throw new NotImplementedException();

        public IDepartmentRepo DepartmentRepository => throw new NotImplementedException();

        public int SaveChanges() => _Dbcontext.SaveChanges();

    }