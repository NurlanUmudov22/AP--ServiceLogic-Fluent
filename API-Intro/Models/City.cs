namespace API_Intro.Models
{
    public class City : BaseEntity
    {
        public string Name { get; set; }

        public int Population { get; set; }

        public double Area { get; set; }

        public int CountryId { get; set; }
        public Country Country{ get; set; }
    }
}
