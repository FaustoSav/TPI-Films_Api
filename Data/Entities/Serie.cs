using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using FilmsAPI.Data.Enum;

namespace FilmsAPI.Data.Entities
{
    public class Serie : Media
    {
        public override string MediaType { get { return "serie"; } }
        public int Seasons { get; set; }
        public int Episodes { get; set; }
    }
}
