using FilmsAPI.Data.Entities;
using FilmsAPI.Data.Models.Movie;
using FilmsAPI.Services.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace FilmsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
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

        [HttpGet("DeletedMovies")]
        public IActionResult GetDeletedMovies()
        {
            string role = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role).Value.ToString();
            if (role == "Admin")
            {
                return Ok(_movieService.GetDeletedMovies());

            }
            return Forbid("Permisos insuficientes");


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

            List<Movie>? movie = _movieService.GetMoviesByTitle(title);

            if (movie == null)
            {

                return NotFound("No se encuentra ninguna pelicula con ese titulo");
            }

            return Ok(movie);
        }

        [HttpDelete("deleteId")]

        public IActionResult DeleteMovie([FromQuery] int deleteId)
        {

            string role = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role).Value.ToString();
            if (role == "Admin")
            {
                _movieService.RemoveMovie(deleteId);
                return Ok("Pelicula eliminada");
            }
            return Forbid("Permisos insuficientes");


        }

        [HttpPost]
        public IActionResult AddMovie([FromBody] MoviePost movie)
        {
            string role = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role).Value.ToString();
            if (role == "Admin")
            {
                Movie Movie = new Movie()
                {

                    Title = movie.Title,
                    Description = movie.Description,
                    Genre = movie.Genre,
                    Duration = movie.Duration,
                };

                int movieId = _movieService.AddMovie(Movie);
                return Ok(movieId);
            }
            return Forbid("Permisos insuficientes");


        }


    }
}
