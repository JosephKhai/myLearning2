
using myLearning.Common.Utils;
using myLearning.DTO;
using myLearning.Entities;
using myLearning.Common.Service;
using myLearning.Common.Infrastructure.IServices;
using myLearning.DataAccess.EFCore.Repositories;
using myLearning.DataAccess.EFCore;
using myLearning.Infrastructure.IServices;

namespace myLearning.Services.Services
{
    public class CityService : BaseService, ICityServices
    {
        private readonly CityRepository _cityRepository;

        public CityService(ICurrentContextProvider currentContextProvider, CityRepository cityRepository) : base(currentContextProvider)
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

        public async Task<IEnumerable<CityDto>> GetAllCities(int pageIndex, int pageSize)
        {
            var citys = await _cityRepository.GetAllCities(pageIndex, pageSize, _session);
            return citys.MapTo<IEnumerable<CityDto>>();
        }


        public async Task<ApiResult<CityDto>> GetPageResultAsync(int pageIndex, int pageSize)
        {
            var cityResult = await _cityRepository.GetPageResultAsync(pageIndex, pageSize, _session);

            var data = cityResult.Data;
            var total = data.Count();

            var mappedData = data.Select(city => city.MapTo<CityDto>()).ToList();

            return new ApiResult<CityDto>(mappedData, total, pageIndex, pageSize);

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
