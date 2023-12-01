using FilmsAPI.Data.Entities;
using FilmsAPI.Data.Enum;
using FilmsAPI.Data.Models.FavoriteMedia;

namespace FilmsAPI.Services.Interface
{
    public interface IFavoritesMedia
    {
        public List<FavoriteMedia> GetAllFavorites(int userId);
        public int AddToFavorites(FavoriteMediaPostDto mediaToAdd, int userId);
        public void RemoveFromFavorites(int favoriteId, int userId);
        public FavoriteMedia? GetFavoriteById( int mediaId, int userId );
        
    }
}
