using Microsoft.AspNetCore.Mvc;
using myLearning.DTO;
using myLearning.Infrastructure.IServices;

namespace myLearningAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private readonly ICountryServices _countryServices;

        public CountryController(ICountryServices countryServices)
        {
            _countryServices = countryServices;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCountries()
        {
            var countries = await _countryServices.GetAllCountries();
            return Ok(countries);

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCountryById(int Id)
        {
            var country = await _countryServices.GetCountryById(Id);
            return Ok(country);
        }

        [HttpPost]
        public async Task AddCounty(CountryDto newCountry)
        {
          await _countryServices.AddCounty(newCountry);
        }

        [HttpPut]
        public async Task UpdateCountry(CountryDto updateCountry)
        {
            await _countryServices.UpdateCountry(updateCountry);
        }


        [HttpDelete]
        public async Task DeleteCountry(int Id)
        {
            await _countryServices.DeleteCountry(Id);
        }


    }
}
