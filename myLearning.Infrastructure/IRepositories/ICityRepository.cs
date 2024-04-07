using myLearning.Common.Entities;
using myLearning.Entities;

namespace myLearning.Infrastructure.IRepositories
{
    public interface ICityRepository
    {
        Task<IEnumerable<Cities>> GetAllCities(ContextSession session);
        Task<Cities> GetCityById(int cityId, ContextSession session);
        Task AddCity(Cities newCity, ContextSession session);
        Task UpdateCity(Cities updateCity, ContextSession session);
        Task DeleteCity(int Id, ContextSession session);
       
    }
}
