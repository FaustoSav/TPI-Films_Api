﻿
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FilmsAPI.Data.Entities
{
    public abstract class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        [Required]
        public string UserName { get; set; }
        public string UserType { get; set; }

        public bool State { get; set; } = true;
        public ICollection<FavoriteMedia> FavoritesMedia { get; set; } = new List<FavoriteMedia>();

    }
}



