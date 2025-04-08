
using AutoMapper;
using Demo.BusinessLogic.DataTransferObjects.EmployeeDto;
using Demo.BusinessLogic.Factories;
using Demo.DataAccess.Models.EmployeeModel;
using Demo.DataAccess.Repositories.classes;
using Demo.DataAccess.Repositories.interfaces;

namespace Demo.BusinessLogic.Services
{
    public class EmployeeService(IEmployeeRepository _EmployeeRepo ,IMapper _mapper) : IEmployeeService
    {
        public int AddEmployee(CreateEmployeeDto EmployeeDto)
        {
          
            var employee = _mapper.Map<CreateEmployeeDto,Employee>(EmployeeDto);
           return   _EmployeeRepo.Add(employee);
          

        }

        public bool DeleteEmployee(int id)
        {
            var employee = _EmployeeRepo.GetById(id);
            if (employee is null) return false;

            else
            {
              employee.IsDeleted = true;
              return  _EmployeeRepo.Update(employee) > 0 ? true : false;
            }
        }

      

        public IEnumerable<EmployeeDto>? GetAllEmployees()
        {
            throw new NotImplementedException();
        }



        public IEnumerable<EmployeeDto>? GetAllEmployees(string? EmployeeSearchName)
        {
            IEnumerable<Employee> employees;
            if (string.IsNullOrEmpty(EmployeeSearchName))

                employees = _EmployeeRepo.GetAll();
            else

                employees = _EmployeeRepo.GetAll(E => E.Name.ToLower().Contains(EmployeeSearchName.ToLower()));

            var employeeDto = _mapper.Map<IEnumerable<Employee>, IEnumerable<EmployeeDto>>(employees);
            return employeeDto;
        }

        
        public EmployeeDetailsDto? GetEmployeeById(int id)
        {
            var employee = _EmployeeRepo.GetById(id);
            var employeeDto = _mapper.Map<Employee, EmployeeDetailsDto>(employee);
            return employeeDto;

        }

        public int UpdateEmployee(UpdatedEmployeeDto EmployeeDto)
        {
         
            return _EmployeeRepo.Update(_mapper.Map<UpdatedEmployeeDto, Employee>(EmployeeDto));
        }
    }
}
