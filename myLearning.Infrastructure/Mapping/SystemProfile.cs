using AutoMapper;
using myLearning.Application.City;
using myLearning.Application.Country;
using myLearning.Entities;

namespace myLearning.Infrastructure.Mapping
{
    public class SystemProfile : Profile
    {
        public SystemProfile()
        {
            CreateMap<CityDto, City>().ReverseMap();
            CreateMap<CountryDto, Country>().ReverseMap();
        }
    }
}
