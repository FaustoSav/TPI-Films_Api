using System.ComponentModel.DataAnnotations;

namespace FilmsAPI.Data.Models.Serie
{
    public class SeriePost
    {
        [Required]
        public string Title { get; set; } = string.Empty;

        [Required]
        public string Description { get; set; } = string.Empty;

        [Required]
        public string Genre { get; set; }

        [Required]
        public int Seasons { get; set; }

        [Required]
        public int Episodes { get; set; }
    }
}
