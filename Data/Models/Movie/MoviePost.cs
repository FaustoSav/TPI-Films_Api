using FilmsAPI.Data.Enum;
using System.ComponentModel.DataAnnotations;

namespace FilmsAPI.Data.Models.Movie
{
    public class MoviePost
    {
        [Required]
        public string Title { get; set; } = string.Empty;
        [Required]

        public string Description { get; set; } = string.Empty;
        [Required]
        public string Genre { get; set; }
        [Required]
        public int Duration { get; set; }

    }
}
