using FilmsAPI.Data.Enum;
using System.ComponentModel.DataAnnotations;

namespace FilmsAPI.Data.Models.FavoriteMedia
{
    public class FavoriteMediaPostDto
    {


        [Required]
        public int MediaId { get; set; }
        [Required]
        public MediaType MediaType { get; set; }
    }
}
