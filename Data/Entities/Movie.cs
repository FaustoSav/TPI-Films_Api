using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using FilmsAPI.Data.Enum;

namespace FilmsAPI.Data.Entities
{
    public class Movie : Film
    {
        public int Duration  { get; set; }
    }
}
