using myLearning.Application.City;

namespace myLearning.Application.Country
{
    public class CountryDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string ISO2 { get; set; } = null!;
        public string ISO3 { get; set; } = null!;
        public ICollection<CityDto>? Cities { get; set; } = null!;
    }
}
