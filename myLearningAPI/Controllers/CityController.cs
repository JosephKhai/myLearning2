using Microsoft.AspNetCore.Mvc;
using myLearning.DataAccess.EFCore.IRepository;
using myLearning.Entities;



namespace myLearningAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : ControllerBase
    {

        private readonly ICityRepository _cityRepository;

        public CityController(ICityRepository cityRepository)
        {
            _cityRepository = cityRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCities(int pageIndex = 0, int pageSize = 10)
        {
            var city = await _cityRepository.GetAllCities(pageIndex, pageSize);
            return Ok(city);
        }

        [HttpGet]
        [Route("GetAllCitiesPagination")]
        public async Task<IActionResult> GetAllCitiesPagination(
            int pageIndex = 0,
            int pageSize = 10,
            string? sortColumn = null,
            string? sortOrder = null,
            string? filterColumn = null,
            string? filterQuery = null
            )
        {
            var cityResult = await _cityRepository.GetPageResultAsync(
                pageIndex,
                pageSize, 
                sortColumn, 
                sortOrder, 
                filterColumn, 
                filterQuery);

            return Ok(cityResult);
        }



        [HttpGet("{id}")]
        public async Task<IActionResult> GetCityById(int id)
        {
            var cities = await _cityRepository.GetCityById(id);
            return Ok(cities);
        }

        [HttpPost("create")]
        public async Task AddCity(Cities newCity)
        {
         await _cityRepository.AddCity(newCity);
   
        }


        [HttpPut("update/{id}")]
        public async Task<IActionResult> UpdateCity(int id, [FromBody]Cities city)
        {
            if(id != city.Id)
            {
                return BadRequest();
            }

            try
            {
                await _cityRepository.UpdateCity(city);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error updating city");
            }

            return Ok(city);
             
        }

        [HttpDelete]
        public async Task DeleteCity(int Id)
        {
            await _cityRepository.DeleteCity(Id);
        }


        [HttpPost]
        [Route("IsDuplicate")]
        public bool IsDuplicateCity(Cities city)
        {
            return _cityRepository.IsDuplicateCity(city);
        }






    }
}
