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
        Task<IEnumerable<Cities>> GetAllCities();
        Task<ApiResult<Cities>> GetPageResultAsync(
            int pageIndex, 
            int pageSize, 
            string sortColumn, 
            string sortOrder,
            string filterColumn,
            string filterQuery
            );
        Task<Cities> GetCityById(int cityId);
        Task AddCity(Cities newCity);
        Task UpdateCity(Cities updateCity);
        Task DeleteCity(int Id);
        bool IsDuplicateCity(Cities city);
    }
}
