using FilmsAPI.Data.Enum;
using System.ComponentModel.DataAnnotations;

namespace FilmsAPI.Data.Models.FavoriteMedia
{
    public class FavoriteMediaPostDto
    {


        [Required]
        public int MediaId { get; set; }
        [Required]
        [RegularExpression("^(Movie|Serie)$", ErrorMessage = "El valor de mediaType debe ser 'Movie' o 'Serie'.")]
        public MediaType MediaType { get; set; }
    }
}
