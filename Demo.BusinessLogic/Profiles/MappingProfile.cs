
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
                .ForMember(dest=> dest.empType , options => options.MapFrom(src => src.employeeType))
                .ForMember(dest => dest.Department, options => options.MapFrom(src => src.Department != null ? src.Department.Name : null));

            CreateMap<Employee, EmployeeDetailsDto>()
                .ForMember(dest=> dest.HiringDate , options => options.MapFrom(src => DateOnly.FromDateTime(src.HiringDate)))
                .ForMember(dest => dest.Department, options => options.MapFrom(src => src.Department != null ? src.Department.Name : null))
                .ForMember(dist => dist.Image , option => option.MapFrom(src => src.ImageName)); 
            ;

            CreateMap<CreateEmployeeDto, Employee>().ReverseMap();
           
            CreateMap<Employee, UpdatedEmployeeDto>();
            CreateMap<UpdatedEmployeeDto, Employee>();
            CreateMap<Employee, EmployeeDetailsDto>();
        

    }
        
            
        
    }
}
