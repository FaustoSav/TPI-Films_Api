using FilmsAPI.Data.Enum;

namespace FilmsAPI.Data.Models.FavoriteMedia
{
    public class FavoriteMediaPostDto
    {
  
        public string Title { get; set; } = "Default Value";
        public string Description { get; set; } = string.Empty;
        public string Genre { get; set; } = string.Empty;
        public MediaType MediaType { get; set; }
    }
}
