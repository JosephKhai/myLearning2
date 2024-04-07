using myLearning.DTO;

namespace myLearning.Infrastructure.IServices
{
    public interface ICountryServices
    {
        Task<IEnumerable<CountryDto>> GetAllCountries();
        Task<CountryDto> GetCountryById(int Id);
        Task AddCounty(CountryDto newCountry);
        Task UpdateCountry(CountryDto updateCountry);
        Task DeleteCountry(int Id);
    }
}
