using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using FilmsAPI.Data.Enum;

namespace FilmsAPI.Data.Entities
{
    public class Movie : Media
    {
        public int Duration  { get; set; }
       public  MediaType MediaType { get; set; } = MediaType.Movie;

    }
}
