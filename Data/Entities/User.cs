using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FilmsAPI.Data.Entities
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }

        [Required]
        public string UserName { get; set; }
        public string UserType { get; set; }

        public List<Movie> Movies { get; set; } = new List<Movie>();
        public List<Serie> Series { get; set; } = new List<Serie>();
    }
}
