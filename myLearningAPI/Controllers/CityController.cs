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
        public async Task<IActionResult> GetAllCitiesPagination(int pageIndex = 0, int pageSize = 10)
        {
            var cityResult = await _cityRepository.GetPageResultAsync(pageIndex, pageSize);
            return Ok(cityResult);
        }



        [HttpGet("{id}")]
        public async Task<IActionResult> GetCityById(int id)
        {
            var cities = await _cityRepository.GetCityById(id);
            return Ok(cities);
        }

        [HttpPost]
        public async Task AddCity(Cities newCity)
        {
         await _cityRepository.AddCity(newCity);
   
        }


        [HttpPut]
        public async Task UpdateCity(Cities updateCity)
        {
             await _cityRepository.UpdateCity(updateCity);
        }

        [HttpDelete]
        public async Task DeleteCity(int Id)
        {
            await _cityRepository.DeleteCity(Id);
        }







    }
}
