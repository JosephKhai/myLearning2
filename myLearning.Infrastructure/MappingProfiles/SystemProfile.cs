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

            //CreateMap<CityDto, Cities>()
            //    .ForMember(dest => dest.Id, opts => opts.MapFrom(source => source.Id))
            //    .ForMember(dest => dest.Name, opts => opts.MapFrom(source => source.Name))
            //    .ForMember(dest => dest.Lat, opts => opts.MapFrom(source => source.Lat))
            //    .ForMember(dest => dest.Lon, opts => opts.MapFrom(source => source.Lon))
            //    .ForMember(dest => dest.CountryId, opts => opts.MapFrom(source => source.CountryId))
            //    .ForMember(dest => dest.Country, opts => opts.MapFrom(source => source.Country))
            //    .ReverseMap();

           
        }
    }
}
