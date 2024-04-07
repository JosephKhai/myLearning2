using myLearning.Common.Entities;
using myLearning.Entities;

namespace myLearning.Infrastructure.IRepositories
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
