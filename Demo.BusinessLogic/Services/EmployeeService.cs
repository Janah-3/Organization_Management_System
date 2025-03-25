
using Demo.BusinessLogic.DataTransferObjects.EmployeeDto;
using Demo.BusinessLogic.Factories;
using Demo.DataAccess.Repositories.classes;
using Demo.DataAccess.Repositories.interfaces;

namespace Demo.BusinessLogic.Services
{
    public class EmployeeService(IEmployeeRepository _EmployeeRepo) : IEmployeeService
    {
        public int AddEmployee(CreateEmployeeDto EmployeeDto)
        {
            var employee = EmployeeDto.ToEntity();
           return   _EmployeeRepo.Add(employee);
          

        }

        public bool DeleteEmployee(int id)
        {
            var employee = _EmployeeRepo.GetById(id);
            if (employee is null) return false;

            else
            {
                int result = _EmployeeRepo.remove(employee);
                return result > 0 ? true : false;
            }
        }

        public IEnumerable<EmployeeDto>? GetAllEmployees()
        {
            var employees = _EmployeeRepo.GetAll();
            return employees.Select(e => e.ToEmployeeDto()).ToList();
        }

        public EmployeeDetailsDto? GetEmployeeById(int id)
        {
            var employee = _EmployeeRepo.GetById(id);
            return employee?.ToEmployeeDetailsDto();
        }

        public int UpdateEmployee(UpdatedEmployeeDto EmployeeDto)
        {
            var employee = EmployeeDto.ToEntity();
            return _EmployeeRepo.Update(employee);
        }
    }
}
