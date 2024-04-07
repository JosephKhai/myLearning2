
using myLearning.Common.Utils;
using myLearning.DTO;
using myLearning.Entities;
using myLearning.Infrastructure.IRepositories;
using myLearning.Infrastructure.IServices;
using myLearning.Common.Service;
using myLearning.Common.Infrastructure.IServices;

namespace myLearning.Services.Services
{
    public class CityService : BaseService, ICityServices
    {
        private readonly ICityRepository _cityRepository;

        public CityService(ICurrentContextProvider currentContextProvider, ICityRepository cityRepository) : base(currentContextProvider)
        {
            _cityRepository = cityRepository;
        }

        public async Task AddCity(CityDto newCity)
        {
            var entity = newCity.MapTo<Cities>();
            await _cityRepository.AddCity(entity, _session);
           
        }

        public async Task DeleteCity(int Id)
        {
            await _cityRepository.DeleteCity(Id, _session);

        }

        public async Task<IEnumerable<CityDto>> GetAllCities()
        {
            var citys = await _cityRepository.GetAllCities(_session);
            return citys.MapTo<IEnumerable<CityDto>>();
        }

        public async Task<CityDto> GetCityById(int cityId)
        {
            var cities = await _cityRepository.GetCityById(cityId, _session);
            return cities.MapTo<CityDto>();

        }

        public async Task UpdateCity(CityDto updateCity)
        {
            var entity = updateCity.MapTo<Cities>();
            await _cityRepository.UpdateCity(entity, _session);
        }
    }
}
