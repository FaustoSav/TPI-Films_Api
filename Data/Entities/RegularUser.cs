namespace FilmsAPI.Data.Entities
{
    public class RegularUser : User
    {

        public List<Movie> Movies { get; set; } = new List<Movie>();
        public List<Serie> Series { get; set; } = new List<Serie>();
    }
}
