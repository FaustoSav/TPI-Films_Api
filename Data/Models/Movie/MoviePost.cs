using FilmsAPI.Data.Enum;

namespace FilmsAPI.Data.Models.Movie
{
    public class MoviePost
    {

        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Genre { get; set; }
        public int Duration { get; set; }

    }
}
