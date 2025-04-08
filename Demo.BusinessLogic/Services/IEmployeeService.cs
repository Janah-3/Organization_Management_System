
using Demo.BusinessLogic.DataTransferObjects.EmployeeDto;

namespace Demo.BusinessLogic.Services
{
    public interface IEmployeeService 
    {
        int AddEmployee(CreateEmployeeDto EmployeeDto);
        bool DeleteEmployee(int id);
        IEnumerable<EmployeeDto>? GetAllEmployees(string? EmployeeSearchName);
        EmployeeDetailsDto? GetEmployeeById(int id);
        int UpdateEmployee(UpdatedEmployeeDto EmployeeDto);
    }
}
