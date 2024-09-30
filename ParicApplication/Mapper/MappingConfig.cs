using AutoMapper;
using ParicApplication.ParicServices.DTO.DepartmentsDTO;
using ParicApplication.ParicServices.DTO.RequestsDTO;
using ParicDomain.Entities;

namespace ParicApplication.Mapper
{
	public class MappingConfig : Profile
	{
		public MappingConfig()
        {
			CreateMap<Department, CreateDepartmentDTO>().ReverseMap();
			CreateMap<UpdateDepartmentDTO, Department>().ReverseMap();
			CreateMap<RequestDTO, Requests>().ReverseMap();
		}
    }
}
