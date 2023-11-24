using FilmsAPI.Data.Enum;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FilmsAPI.Data.Entities
{
    public class Media

    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MediaId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Genre { get; set; }

        public bool State { get; set; } = true;

    }
}
