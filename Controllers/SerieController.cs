using FilmsAPI.Data.Entities;
using FilmsAPI.Data.Models.Movie;
using FilmsAPI.Data.Models.Serie;
using FilmsAPI.Services.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FilmsAPI.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
   
    public class SerieController : ControllerBase
    {


        private readonly ISerieService _serieService;


        public SerieController(ISerieService serieService)
        {

            _serieService = serieService;
        }



        [HttpGet]
        public IActionResult GetAllMovies()
        {

            return Ok(_serieService.GetAllSeries());


        }

        [HttpGet("id")]
        public IActionResult GetSerieById([FromQuery] int id)
        {

            Serie? serie = _serieService.GetSerieById(id);

            if (serie == null)
            {

                return NotFound("No se encuentra ninguna serie on ese ID");

            }

            return Ok(serie);

        }


        [HttpGet("title")]
        public IActionResult GetSerieByTitle([FromQuery] string title)
        {

            Serie? serie = _serieService.GetSerieByTitle(title);

            if (serie == null)
            {

                return NotFound("No se encuentra ninguna serie con ese titulo");
            }

            return Ok(serie);
        }

        [HttpDelete("deleteId")]

        public IActionResult DeleteSerie([FromQuery] int deleteId)
        {

            _serieService.RemoveSerie(deleteId);
            return Ok("Serie eliminada");

        }

        [HttpPost]
        public IActionResult AddMovie([FromBody] SeriePost serie)
        {
            var Serie = new Serie()
            {

                Title = serie.Title,
                Description = serie.Description,
                Genre = serie.Genre,
                Seasons = serie.Seasons,
                Episodes = serie.Episodes,
            };

            int serieId = _serieService.AddSerie(Serie);
            return Ok(serieId);

        }


    }
}
