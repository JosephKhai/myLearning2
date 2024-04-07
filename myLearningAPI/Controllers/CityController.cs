using Microsoft.AspNetCore.Mvc;
using myLearning.DTO;
using myLearning.Infrastructure.IServices;


namespace myLearningAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : ControllerBase
    {

        private readonly ICityServices _cityServices;

        public CityController(ICityServices cityServices)
        {
            _cityServices = cityServices;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCities()
        {
            var city = await _cityServices.GetAllCities();
            return Ok(city);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCityById(int id)
        {
            var cities = await _cityServices.GetCityById(id);
            return Ok(cities);
        }

        [HttpPost]
        public async Task AddCity(CityDto newCity)
        {
         await _cityServices.AddCity(newCity);
   
        }


        [HttpPut]
        public async Task UpdateCity(CityDto updateCity)
        {
             await _cityServices.UpdateCity(updateCity);
        }

        [HttpDelete]
        public async Task DeleteCity(int Id)
        {
            await _cityServices.DeleteCity(Id);
        }







    }
}
