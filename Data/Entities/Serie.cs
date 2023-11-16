using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using FilmsAPI.Data.Enum;

namespace FilmsAPI.Data.Entities
{
    public class Serie : Film
    {
        public int Seasons { get; set; }

        public int Episodes { get; set; }
    }
}
