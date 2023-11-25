using FilmsAPI.Data.Entities;
using FilmsAPI.Data.Models.Movie;
using FilmsAPI.Services.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FilmsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
   
    public class MovieController : ControllerBase
    {


        private readonly IMovieService _movieService;


        public MovieController(IMovieService movieService)
        {

            _movieService = movieService;
        }



        [HttpGet]
        public IActionResult GetAllMovies()
        {

            return Ok(_movieService.GetAllMovies());


        }

        [HttpGet("id")]
        public IActionResult GetMovieById([FromQuery] int id)
        {

            Movie? movie = _movieService.GetMovieById(id);

            if (movie == null)
            {

                return NotFound("No se encuentra ninguna pelicula on ese ID");

            }

            return Ok(movie);

        }


        [HttpGet("title")]
        public IActionResult GetMovieByTitle([FromQuery] string title)
        {

            Movie? movie = _movieService.GetMovieByTitle(title);

            if (movie == null)
            {

                return NotFound("No se encuentra ninguna pelicula con ese titulo");
            }

            return Ok(movie);
        }

        [HttpDelete("deleteId")]

        public IActionResult DeleteMovie([FromQuery] int deleteId)
        {

            _movieService.RemoveMovie(deleteId);
            return Ok("Pelicula eliminada");

        }

        [HttpPost]
        public IActionResult AddMovie([FromBody] MoviePost movie)
        {
            var Movie = new Movie()
            {

                Title = movie.Title,
                Description = movie.Description,
                Genre = movie.Genre,
                Duration = movie.Duration,
            };

            int movieId = _movieService.AddMovie(Movie);
            return Ok(movieId);

        }


    }
}
