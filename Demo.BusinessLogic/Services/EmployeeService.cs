
using AutoMapper;
using Demo.BusinessLogic.DataTransferObjects.EmployeeDto;
using Demo.BusinessLogic.Factories;
using Demo.BusinessLogic.Services.AttachmentServices;
using Demo.DataAccess.Models.EmployeeModel;
using Demo.DataAccess.Repositories;
using Demo.DataAccess.Repositories.classes;
using Demo.DataAccess.Repositories.interfaces;

namespace Demo.BusinessLogic.Services
{
    public class EmployeeService(IUnitOfWork _unitOfWork ,IMapper _mapper , IAttachmentService _attachmentService) : IEmployeeService
    {
        public int AddEmployee(CreateEmployeeDto EmployeeDto)
        {
          
            var employee = _mapper.Map<CreateEmployeeDto,Employee>(EmployeeDto);

            if (EmployeeDto.Image != null)
            {
            employee.ImageName = _attachmentService.Upload(EmployeeDto.Image , "Images");
            }

            _unitOfWork.EmployeeRepository.Add(employee);//add locally

          return _unitOfWork.SaveChanges() > 0 ? employee.Id : 0; //save to db

        }

        public bool DeleteEmployee(int id)
        {
            var employee = _unitOfWork.EmployeeRepository.GetById(id);
            if (employee is null) return false;

            else
            {
              employee.IsDeleted = true;
               _unitOfWork.EmployeeRepository.Update(employee);
                return _unitOfWork.SaveChanges() > 0 ? true : false; //save to db
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

                employees = _unitOfWork.EmployeeRepository.GetAll();
            else

                employees = _unitOfWork.EmployeeRepository.GetAll(E => E.Name.ToLower().Contains(EmployeeSearchName.ToLower()));

            var employeeDto = _mapper.Map<IEnumerable<Employee>, IEnumerable<EmployeeDto>>(employees);
            return employeeDto;
        }

        
        public EmployeeDetailsDto? GetEmployeeById(int id)
        {
            var employee = _unitOfWork.EmployeeRepository.GetById(id);
            var employeeDto = _mapper.Map<Employee, EmployeeDetailsDto>(employee);
            return employeeDto;

        }

        public int UpdateEmployee(UpdatedEmployeeDto EmployeeDto)
        {
         
             _unitOfWork.EmployeeRepository.Update(_mapper.Map<UpdatedEmployeeDto, Employee>(EmployeeDto));
            return _unitOfWork.SaveChanges() > 0 ? EmployeeDto.Id : 0; //save to db
        }
    }
}
