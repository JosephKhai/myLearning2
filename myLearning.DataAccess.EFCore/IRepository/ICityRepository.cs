using myLearning.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myLearning.DataAccess.EFCore.IRepository
{
    public interface ICityRepository
    {
        Task<IEnumerable<Cities>> GetAllCities(int pageIndex, int pageSize);
        Task<Cities> GetCityById(int cityId);
        Task AddCity(Cities newCity);
        Task UpdateCity(Cities updateCity);
        Task DeleteCity(int Id);
    }
}
