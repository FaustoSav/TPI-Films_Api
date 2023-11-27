using FilmsAPI.Data.Entities;
using FilmsAPI.Data.Enum;
using FilmsAPI.Data.Models.FavoriteMedia;

namespace FilmsAPI.Services.Interface
{
    public interface IFavoritesMedia
    {
        public List<FavoriteMedia> GetAllFavorites();
        public int AddToFavorites(FavoriteMedia favoriteToAdd);
        public void RemoveFromFavorites(int id);
        public FavoriteMedia? GetFavoriteById( int id );
        public List<FavoriteMedia>? GetFavoriteByTitle( string title );
    }
}
