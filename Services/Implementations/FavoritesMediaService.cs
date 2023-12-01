using FilmsAPI.Data.DBContext;
using FilmsAPI.Data.Entities;
using FilmsAPI.Data.Enum;
using FilmsAPI.Data.Models.FavoriteMedia;
using FilmsAPI.Services.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;
using System.Security.Claims;

namespace FilmsAPI.Services.Implementations
{
    public class FavoritesMediaService : IFavoritesMedia
    {
        private readonly MediaContext _mediaContext;
        private readonly IMovieService _movieService;
        private readonly ISerieService _serieService;
        private readonly IUserService _userService;

        public FavoritesMediaService(MediaContext mediaContext, IMovieService movieService, ISerieService serieService, IUserService userService)
        {
            _mediaContext = mediaContext;
            _movieService = movieService;
            _serieService = serieService;
            _userService = userService;


        }
        public List<FavoriteMedia> GetAllFavorites(int userId)
        {

            return _mediaContext.FavoritesMedia.Where(f => f.UserId == userId).ToList();


        }


        //public List<FavoriteMedia> GetAllFavorites(int userId);
        //public int AddToFavorites(FavoriteMediaPostDto mediaToAdd, int userId);
        //public void RemoveFromFavorites(int favoriteId, int userId);
        //public FavoriteMedia? GetFavoriteById(int mediaId, int userId);
        public int AddToFavorites(FavoriteMediaPostDto mediaToAdd, int userId)
        {
            FavoriteMedia newFavorite = null;
           
            User currentUser = _mediaContext.Users.FirstOrDefault(u => u.Id == userId);
            if (currentUser == null)
            {
                return -1;
            }

            if (mediaToAdd.MediaType == "Serie")
            {
                Serie? serieToFav = _serieService.GetSerieById(mediaToAdd.MediaId);

                if (serieToFav == null) { return -1; }

                newFavorite = new FavoriteMedia
                {
                    Title = serieToFav.Title,
                    UserId = currentUser.Id,
                    Description = serieToFav.Description,
                    MediaType = "Serie",
                    MediaId = mediaToAdd.MediaId
                };

            }
            if (mediaToAdd.MediaType == "Movie")
            {
                Movie? MovieToFav = _movieService.GetMovieById(mediaToAdd.MediaId);

                if (MovieToFav == null) { return -1; }
                newFavorite = new FavoriteMedia
                {
                    Title = MovieToFav.Title,
                    UserId = currentUser.Id,
                    MediaType = "Movie",
                    MediaId = mediaToAdd.MediaId,
                    
                };
            }


            if (newFavorite != null )
            {
                _mediaContext.FavoritesMedia.Add(newFavorite);
                
                _mediaContext.SaveChanges();
                return newFavorite.MediaId;

            }

            return -1;





        }
        public void RemoveFromFavorites(int favoriteId, int userId)
        {
            FavoriteMedia? favoriteToDelete = _mediaContext.FavoritesMedia.SingleOrDefault(fm => fm.FavoriteMediaId == favoriteId && fm.UserId == userId);

            if (favoriteToDelete != null)
            {
                _mediaContext.Remove(favoriteToDelete);
                _mediaContext.SaveChanges();
            }


        }

        public FavoriteMedia? GetFavoriteById(int mediaId, int userId)
        {
            return _mediaContext.FavoritesMedia.SingleOrDefault(s => s.FavoriteMediaId == mediaId && s.UserId == userId);

        }
 

       

    }
}
