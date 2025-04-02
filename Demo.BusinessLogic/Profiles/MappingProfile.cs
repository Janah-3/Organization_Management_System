
using AutoMapper;
using Demo.BusinessLogic.DataTransferObjects.EmployeeDto;
using Demo.DataAccess.Models.EmployeeModel;

namespace Demo.BusinessLogic.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Employee, EmployeeDto>()
                .ForMember(dest => dest.empGender,options => options.MapFrom(src => src.Gender))
                .ForMember(dest=> dest.empType , options => options.MapFrom(src => src.employeeType));

            CreateMap<Employee, EmployeeDetailsDto>()
                .ForMember(dest=> dest.HiringDate , options => options.MapFrom(src => DateOnly.FromDateTime(src.HiringDate)));
            ;

            CreateMap<CreateEmployeeDto, Employee>().ReverseMap();
           
            CreateMap<Employee, UpdatedEmployeeDto>();
            CreateMap<UpdatedEmployeeDto, Employee>();
            
        }
        
            
        
    }
}
