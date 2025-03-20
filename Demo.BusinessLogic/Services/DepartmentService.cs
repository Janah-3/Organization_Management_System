using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo.DataAccess.Models;
using Demo.DataAccess.Repositories;

namespace Demo.BusinessLogic.Services
{
    public class DepartmentService
    {
        private readonly IDepartmentRepo departmentRepo;
        public DepartmentService(IDepartmentRepo departmentRepo) //1.injection
        {
            this.departmentRepo = departmentRepo;
        }

     
    }
}
