using FilmsAPI.Data.Enum;

namespace FilmsAPI.Services.Interface
{
    public interface IFavoritesMedia
    {
        public void AddToFavorites(/*int id, string title, MediaType mediaType*/);
        public void RemoveFromFavorites(int id);
    }
}
