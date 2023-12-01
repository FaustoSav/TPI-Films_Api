using FilmsAPI.Data.Entities;
using FilmsAPI.Data.Enum;
using FilmsAPI.Data.Models.FavoriteMedia;

namespace FilmsAPI.Services.Interface
{
    public interface IFavoritesMedia
    {
        public List<FavoriteMedia> GetAllFavorites();
        public int AddToFavorites(FavoriteMediaPostDto mediaToAdd);
        public void RemoveFromFavorites(int id);
        public FavoriteMedia? GetFavoriteById( int id );
        public List<FavoriteMedia>? GetFavoriteByTitle( string title );
        public bool FavoriteExists(string  title);
    }
}
