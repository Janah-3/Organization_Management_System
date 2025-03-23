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
    public class EmployeeRepo(AppDbContext dbContext) : GenericRepository<Employee>(dbContext), IEmployeeRepository
    {

    }
}
