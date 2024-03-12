using AutoMapper;
using myLearning.Application.City;
using myLearning.Application.Country;
using myLearning.Application.myOwnFeatures;
using myLearning.Entities;
using myLearning.Entities.Models;

namespace myLearning.Infrastructure.Mapping
{
    public class SystemProfile : Profile
    {
        public SystemProfile()
        {
            CreateMap<CityDto, City>().ReverseMap();
            CreateMap<CountryDto, Country>().ReverseMap();
            CreateMap<myOwnModelDto, myOwnModel>();


            //CreateMap<myOwnModelDto, myOwnModelDto>()
            //    .ForMember(dest => dest.Country.Name,
            //   opts => opts.MapFrom(src => src.Country.Name))
            //   .ForMember(dest => dest.Country.Cities, opts => opts.MapFrom(src => src.Country.Cities))
            //   //add here manay of the members

            //   .ReverseMap();


        }
    }
}
