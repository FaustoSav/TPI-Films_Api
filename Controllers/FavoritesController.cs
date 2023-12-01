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

        [HttpGet]
        public IActionResult GetAllFavorites()
        {
            return Ok(_favoriteMediaService.GetAllFavorites());
        }

        [HttpPost]
        public IActionResult AddFavorite([FromBody] FavoriteMediaPostDto mediaToAdd)
        {

           // var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            

            int newFavoriteId = _favoriteMediaService.AddToFavorites(mediaToAdd);


            if (newFavoriteId == -1)
            {
                return NotFound($"Parece que la {mediaToAdd.MediaType} que queres agregar a favoritos, no existe. Chequear ID y/o asegurarse que el MediaType sea Serie | Movie.");
            }
            return Ok(newFavoriteId);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteFavorite([FromQuery] int id)
        {

            FavoriteMedia favoriteMedia = _favoriteMediaService.GetFavoriteById(id);

            if (favoriteMedia == null)
            {
                return BadRequest();
            }

            _favoriteMediaService.RemoveFromFavorites(id);
            return Ok($"Pelicula {id} eliminada.");
        }

        [HttpGet("id")]
        public IActionResult GetFavoriteById([FromQuery] int id)
        {

            FavoriteMedia? favorite = _favoriteMediaService?.GetFavoriteById(id);

            if (favorite == null)
            {

                return NotFound();
            }
            return Ok(favorite);

        }


        [HttpGet("title")]
        public IActionResult GetFavoritesByTitle([FromQuery] string title)
        {
            List<FavoriteMedia>? favoritesList = _favoriteMediaService.GetFavoriteByTitle(title);

            if (favoritesList == null)
            {
                return NotFound();
            }
            return Ok(favoritesList);
        }


    }



}
