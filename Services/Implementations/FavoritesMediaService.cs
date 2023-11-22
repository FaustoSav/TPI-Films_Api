using FilmsAPI.Data.DBContext;
using FilmsAPI.Data.Entities;
using FilmsAPI.Data.Enum;
using FilmsAPI.Services.Interface;
using System.ComponentModel.DataAnnotations.Schema;

namespace FilmsAPI.Services.Implementations
{
    public class FavoritesMediaService :IFavoritesMedia
    {
        private readonly MediaContext _mediaContext;

        public FavoritesMediaService(MediaContext mediaContext)
        {
            _mediaContext = mediaContext;
        }
        public void AddToFavorites( )
        {
      //Title 


      //UserId 
    
      // MediaType MediaType 

      //  MediaId 
      

    }
        public void RemoveFromFavorites(int id)
        {
            FavoriteMedia? favoriteToDelete = _mediaContext.FavoritesMedia.SingleOrDefault(fm => fm.MediaId == id);
            if (favoriteToDelete != null)
            {
                favoriteToDelete.State = false;
                _mediaContext.Update(favoriteToDelete);
                _mediaContext.SaveChanges();
            }


        }
    }
}
