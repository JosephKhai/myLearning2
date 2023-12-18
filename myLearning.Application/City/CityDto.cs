using myLearning.Application.Country;

namespace myLearning.Application.City
{
    public class CityDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public decimal Lat { get; set; }
        public decimal Lon { get; set; }
        public int CountryId { get; set; }
        public CountryDto? Country { get; set; }
    }
}
