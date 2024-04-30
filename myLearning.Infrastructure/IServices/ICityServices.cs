using myLearning.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myLearning.Infrastructure.IServices
{
    public interface ICityServices
    {
        Task<IEnumerable<CityDto>> GetAllCities(int pageIndex, int pageSize);
        Task<CityDto> GetCityById(int cityId);
        Task AddCity(CityDto newCity);
        Task UpdateCity(CityDto updateCity);
        Task DeleteCity(int Id);
    }
}
