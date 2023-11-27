using FilmsAPI.Data.DBContext;
using FilmsAPI.Data.Entities;
using FilmsAPI.Data.Enum;
using FilmsAPI.Data.Models.FavoriteMedia;
using FilmsAPI.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations.Schema;

namespace FilmsAPI.Services.Implementations
{
    public class FavoritesMediaService : IFavoritesMedia
    {
        private readonly MediaContext _mediaContext;

        public FavoritesMediaService(MediaContext mediaContext)
        {
            _mediaContext = mediaContext;
        }
        public List<FavoriteMedia> GetAllFavorites()
        {

            return _mediaContext.FavoritesMedia.ToList();


        }
        public int AddToFavorites(FavoriteMedia favoriteToAdd)
        {
            _mediaContext.FavoritesMedia.Add(favoriteToAdd);
             _mediaContext.SaveChanges();

            return favoriteToAdd.FavoriteMediaId;

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
            return _mediaContext.FavoritesMedia.Where(f => f.Title.Contains(title)).ToList();
        }
    }
}
