using FilmsAPI.Data.Entities;
using FilmsAPI.Data.Models.Movie;
using FilmsAPI.Data.Models.Serie;
using FilmsAPI.Services.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace FilmsAPI.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    [Authorize]

    public class SerieController : ControllerBase
    {


        private readonly ISerieService _serieService;


        public SerieController(ISerieService serieService)
        {

            _serieService = serieService;
        }



        [HttpGet]
        public IActionResult GetAllSeries()
        {

            return Ok(_serieService.GetAllSeries());


        }

        [HttpGet("DeletedSeries")]
        public IActionResult GetDeletedSeries()
        {
            string role = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role).Value.ToString();


            if (role == "Admin")
            {
                return Ok(_serieService.GetDeletedSeries());

            }
            return Forbid("Permisos insuficientes");


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

            List<Serie> serie = _serieService.GetSeriesByTitle(title);

            if (serie == null)
            {

                return NotFound("No se encuentra ninguna serie con ese titulo");
            }

            return Ok(serie);
        }

        [HttpDelete("deleteId")]

        public IActionResult DeleteSerie([FromQuery] int deleteId)
        {
            string role = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role).Value.ToString();

            Serie? serie = _serieService.GetSerieById(deleteId);
            if (role == "Admin")
            {

                if (serie == null)
                {

                    return NotFound("La serie que desea eliminar no existe.");
                }
                _serieService.RemoveSerie(deleteId);
                return Ok("Serie eliminada");
            }
            return Forbid("Permisos insuficientes");

        }

        [HttpPost]
        public IActionResult AddMovie([FromBody] SeriePost serie)
        {

            string role = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role).Value.ToString();
            if (role == "Admin")
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
            return Forbid("Permisos insuficientes");


        }


    }
}
