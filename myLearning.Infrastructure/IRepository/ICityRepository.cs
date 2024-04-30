using myLearning.Common.Entities;
using myLearning.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myLearning.Infrastructure.IRepository
{
    public interface ICityRepository
    {
        Task<IEnumerable<Cities>> GetAllCities(int pageIndex, int pageSize, ContextSession session);
        Task<Cities> GetCityById(int cityId, ContextSession session);
        Task AddCity(Cities newCity, ContextSession session);
        Task UpdateCity(Cities updateCity, ContextSession session);
        Task DeleteCity(int Id, ContextSession session);
    }
}
