using Microsoft.AspNetCore.Mvc;
using myLearning.DataAccess.EFCore;
using myLearning.DataAccess.EFCore.IRepository;
using myLearning.Entities;

namespace myLearningAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private readonly ICountryRepository _countryRepository;

        public CountryController(ICountryRepository countryRepository)
        {
            _countryRepository = countryRepository;
        }

        [HttpGet("getall")]
        public async Task<IActionResult> GetAllCountries()
        {
            var countries = await _countryRepository.GetAllCountries();
            return Ok(countries);

        }

        [HttpGet]
        [Route("GetAllCountriesPagination")]
        public async Task<IActionResult> GetPageResultAsync(
            int pageIndex = 0,
            int pageSize = 10,
            string? sortColumn = null,
            string? sortOrder = null,
            string? filterColumn = null,
            string? filterQuery = null)
        {
            var cityResult = await _countryRepository.GetPageResultAsync(
                 pageIndex,
                pageSize,
                sortColumn,
                sortOrder,
                filterColumn,
                filterQuery
                );

            return Ok(cityResult);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCountryById(int id)
        {
            var country = await _countryRepository.GetCountryById(id);
            return Ok(country);
        }

        [HttpPost("create")]
        public async Task AddCounty(Countries newCountry)
        {
            await _countryRepository.AddCounty(newCountry);
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> UpdateCountry(int id, [FromBody]Countries country)
        {
            if(id != country.Id)
            {
                return BadRequest();
            }
            try
            {
                await _countryRepository.UpdateCountry(country);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error updating country");
            }

            return Ok(country);
        }


        [HttpDelete]
        public async Task DeleteCountry(int Id)
        {
            await _countryRepository.DeleteCountry(Id);
        }

        [HttpPost]
        [Route("IsDuplicateField")]
        public bool IsDuplicateField(string countryId, string fieldName, string fieldValue)
        {
            return _countryRepository.IsDuplicateCountry(countryId, fieldName, fieldValue);
        }


    }
}
