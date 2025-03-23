using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo.DataAccess.Models.EmployeeModel;

namespace Demo.DataAccess.Repositories.interfaces
{
    internal interface IEmployeeRepository : IGenericRepository<Employee>
    {
       
    }
}
