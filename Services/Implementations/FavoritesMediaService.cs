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
        public List<FavoriteMedia> GetAllFavorites()
        {

            return _mediaContext.FavoritesMedia.ToList();


        }
        public int AddToFavorites(FavoriteMediaPostDto mediaToAdd)
        {
            FavoriteMedia newFavorite = null;
            var currentUserId = _userService.GetCurrentUser();
            User currentUser = _mediaContext.Users.FirstOrDefault(u => u.Id == currentUserId);
            if(currentUserId == null)
            {
                return -1;
            }
            
            if (mediaToAdd.MediaType == MediaType.Serie)
            {
                Serie? serieToFav = _serieService.GetSerieById(mediaToAdd.MediaId);

                if (serieToFav == null) { return -1; }

                newFavorite = new FavoriteMedia
                {
                    Title = serieToFav.Title,
                    UserId = (int)currentUserId,
                    Description = serieToFav.Description,
                    MediaType = serieToFav.MediaType.ToString(),
                    MediaId = mediaToAdd.MediaId
                };

            }
            if (mediaToAdd.MediaType == MediaType.Movie)
            {
                Movie? MovieToFav = _movieService.GetMovieById(mediaToAdd.MediaId);
                    
                if (MovieToFav == null) { }
                newFavorite = new FavoriteMedia
                {
                    Title = MovieToFav.Title,
                    UserId = (int)currentUserId,
                    MediaType = MovieToFav.MediaType.ToString(),
                    MediaId = mediaToAdd.MediaId
                };
            }


            if(newFavorite  != null)
            {
                currentUser.FavoritesMedia.Add(newFavorite);
                _mediaContext.Update(currentUser);
                _mediaContext.SaveChanges(); 
                return newFavorite.MediaId;

            }

            return -1;





        }
        public void RemoveFromFavorites(int id)
        {
            FavoriteMedia? favoriteToDelete = _mediaContext.FavoritesMedia.SingleOrDefault(fm => fm.FavoriteMediaId == id);

            if (favoriteToDelete != null)
            {
                _mediaContext.Remove(favoriteToDelete);
                _mediaContext.SaveChanges();
            }
            

        }

        public FavoriteMedia? GetFavoriteById(int id)
        {
            return _mediaContext.FavoritesMedia.SingleOrDefault(s => s.FavoriteMediaId == id);

        }
        public List<FavoriteMedia>? GetFavoriteByTitle(string title)
        {
            return _mediaContext.FavoritesMedia.Where(f => f.Title.ToLower().Contains(title.ToLower())).ToList();
        }
    }
}
