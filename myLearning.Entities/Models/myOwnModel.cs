namespace myLearning.Entities.Models
{
    public class myOwnModel
    {
        public int Id { get; set; }
        public Country Country { get; set; }
        public IEnumerable<City> City { get; set; }
    }
}
