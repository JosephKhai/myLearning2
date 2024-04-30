using myLearning.Common.Entities;
using myLearning.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myLearning.Infrastructure.IRepository
{
    public interface ICountryRepository
    {
        Task<IEnumerable<Countries>> GetAllCountries(ContextSession session);
        Task<Countries> GetCountryById(int Id, ContextSession session);
        Task AddCounty(Countries newCountry, ContextSession session);
        Task UpdateCountry(Countries updateCountry, ContextSession session);
        Task DeleteCountry(int Id, ContextSession session);
    }
}
