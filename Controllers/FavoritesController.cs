using FilmsAPI.Data.Models.FavoriteMedia;
using FilmsAPI.Services.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FilmsAPI.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    [Authorize]

    public class FavoritesController : Controller
    {
        private readonly IFavoritesMedia _favoriteMediaService;


        public FavoritesController(IFavoritesMedia favoriteMediaService)
        {

            _favoriteMediaService = favoriteMediaService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return Ok();
        }


        /*


        [HttpGet]
        public IActionResult GetAllFavorites()
        {

            return Ok(_favoriteMediaService.GetAllFavorites());
        }


        [HttpPost]
        public IActionResult AddFavorite(FavoriteMediaPostDto favoriteToAdd)
        {

        }

        [HttpDelete("{id}")]

        public IActionResult DeleteFavorite([FromQuery]int id)
        {

        }

        [HttpGet("{id}")]
        public IActionResult GetFavoriteById([FromQuery]int id) { }


        [HttpGet("{title}")]
        public IActionResult GetFavoritesByTitle([FromQuery]string title)
        {

        }


    }
    */


    }
}
