namespace FilmsAPI.Data.Entities
{
    public class Admin : User
    {

        public List<Movie> Movies { get; set; } = new List<Movie>();
        public List<Serie> Series { get; set; } = new List<Serie>();
    }
}
