using AutoMapper;
using LIHE.Models.Domain;
using LIHE.Models.DTO;

namespace LIHE.Mappings
{
	public class AutoMapperProfiles : Profile
	{
		public AutoMapperProfiles()
		{
			CreateMap<AddCountryRequestDto, AddCountryResponseDto>().ReverseMap();
			CreateMap<Country, AddCountryResponseDto>().ReverseMap();
			CreateMap<Country, UpdateCountryRequestDto>().ReverseMap();
			CreateMap<department, DepartmentRequestDto>().ReverseMap();

		}
	}
}
