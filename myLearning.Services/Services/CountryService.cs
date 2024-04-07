
using myLearning.Common.Utils;
using myLearning.DTO;
using myLearning.Entities;
using myLearning.Infrastructure.IRepositories;
using myLearning.Infrastructure.IServices;
using myLearning.Common.Service;
using myLearning.Common.Infrastructure.IServices;

namespace myLearning.Services.Services
{
    public class CountryService : BaseService, ICountryServices
    {
        private readonly ICountryRepository _countryRepository;

        public CountryService(ICurrentContextProvider currentContextProvider, ICountryRepository countryRepository) : base(currentContextProvider)
        {
            _countryRepository = countryRepository;
        }

        public async Task AddCounty(CountryDto newCountry)
        {
            var entity = newCountry.MapTo<Countries>();
            await _countryRepository.AddCounty(entity, _session);

        }

        public async Task DeleteCountry(int Id)
        {
            await _countryRepository.DeleteCountry(Id, _session);
        }

        public async Task<IEnumerable<CountryDto>> GetAllCountries()
        {
            var countries = await _countryRepository.GetAllCountries(_session);
            return countries.MapTo<IEnumerable<CountryDto>>();
        }

        public async Task<CountryDto> GetCountryById(int Id)
        {
            var entityCountry = await _countryRepository.GetCountryById(Id, _session);
            return entityCountry.MapTo<CountryDto>();

        }

        public async Task UpdateCountry(CountryDto updateCountry)
        {
            var entity = updateCountry.MapTo<Countries>();
            await _countryRepository.UpdateCountry(entity, _session);
        }
    }
}
