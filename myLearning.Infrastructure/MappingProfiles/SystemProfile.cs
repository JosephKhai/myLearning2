using AutoMapper;
using myLearning.DTO;
using myLearning.Entities;

namespace myLearning.Infrastructure.MappingProfiles
{
    public class SystemProfile : Profile
    {
        public SystemProfile()
        {
            CreateMap<CityDto, Cities>().ReverseMap();
            CreateMap<CountryDto, Countries>().ReverseMap();



           
        }
    }
}
