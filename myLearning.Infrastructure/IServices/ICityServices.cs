using myLearning.DTO;

namespace myLearning.Infrastructure.IServices
{
    public interface ICityServices
    {
        Task<IEnumerable<CityDto>> GetAllCities();
        Task<CityDto> GetCityById(int cityId);
        Task AddCity(CityDto newCity);
        Task UpdateCity(CityDto updateCity);
        Task DeleteCity(int Id);


    }
}
