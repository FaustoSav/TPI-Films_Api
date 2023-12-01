using FilmsAPI.Data.Entities;
using FilmsAPI.Data.Enum;
using FilmsAPI.Data.Models.FavoriteMedia;
using FilmsAPI.Services.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace FilmsAPI.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    [Authorize]

    public class FavoritesController : ControllerBase
    {
        private readonly IFavoritesMedia _favoriteMediaService;


        public FavoritesController(IFavoritesMedia favoriteMediaService)
        {

            _favoriteMediaService = favoriteMediaService;
        }

        [HttpGet("Favorites")]
        public IActionResult GetAllFavorites([FromQuery] int userId)
        {
            return Ok(_favoriteMediaService.GetAllFavorites(userId));
        }

        [HttpPost]
        public IActionResult AddFavorite([FromBody] FavoriteMediaPostDto mediaToAdd, int userId)
        {

           // var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            

            int newFavoriteId = _favoriteMediaService.AddToFavorites(mediaToAdd, userId);


            if (newFavoriteId == -1)
            {
                return NotFound();
            }
            return Ok(newFavoriteId);
        }

        //public List<FavoriteMedia> GetAllFavorites(int userId);
        //public int AddToFavorites(FavoriteMediaPostDto mediaToAdd, int userId);
        //public void RemoveFromFavorites(int favoriteId, int userId);
        //public FavoriteMedia? GetFavoriteById(int mediaId, int userId);
        [HttpDelete]
        public IActionResult DeleteFavorite([FromQuery] int mediaId, int userId)
        {

            FavoriteMedia favoriteMedia = _favoriteMediaService.GetFavoriteById(mediaId, userId);

            if (favoriteMedia == null)
            {
                return BadRequest();
            }

            _favoriteMediaService.RemoveFromFavorites(favoriteMedia.FavoriteMediaId, userId);
            return Ok(favoriteMedia.FavoriteMediaId);
        }

        [HttpGet("id")]
        public IActionResult GetFavoriteById([FromQuery] int mediaId, int userId)
        {

            FavoriteMedia? favorite = _favoriteMediaService.GetFavoriteById(mediaId, userId);

            if (favorite == null)
            {

                return NotFound();
            }
            return Ok(favorite);

        }


    }



}
