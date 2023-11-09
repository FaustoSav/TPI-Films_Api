using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using FilmsAPI.Data.Enum;

namespace FilmsAPI.Data.Entities
{
    public class Serie
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public int Seasons { get; set; }
        public string Description { get; set; } = string.Empty;
        public Genre Genre { get; set; } 

        public int Episodes { get; set; }
    }
}
