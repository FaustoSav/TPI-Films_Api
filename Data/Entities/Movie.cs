using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using FilmsAPI.Data.Enum;

namespace FilmsAPI.Data.Entities
{
    public class Movie : Media
    {
        public int Duration  { get; set; }

        public override MediaType MediaType { get { return MediaType.Movie; } }

    }
}
