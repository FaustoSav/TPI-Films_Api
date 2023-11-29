using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using FilmsAPI.Data.Enum;

namespace FilmsAPI.Data.Entities
{
    public class Serie : Media
    {
        public override MediaType MediaType { get { return MediaType.Serie; } }
        public int Seasons { get; set; }
        public int Episodes { get; set; }
    }
}
