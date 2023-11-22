using FilmsAPI.Data.Enum;

namespace FilmsAPI.Data.Models.FavoriteMedia
{
    public class FavoriteMediaPostDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = "Default Value";
        public MediaType MediaType { get; set; }
    }
}
