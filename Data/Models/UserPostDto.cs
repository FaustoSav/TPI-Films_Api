using System.ComponentModel.DataAnnotations;

namespace FilmsAPI.Data.Models
{
    public class UserPostDto
    {

        public string? Name { get; set; }
        public string? LastName { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required]
        public string UserType { get; set; }
    }
}
