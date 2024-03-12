using myLearning.Application.City;
using myLearning.Application.Country;

namespace myLearning.Application.myOwnFeatures
{
    public class myOwnModelDto
    {
        public int Id { get; set; }
        public CountryDto Country { get; set; }
        public IEnumerable<CityDto> City { get; set; }
    }
}
