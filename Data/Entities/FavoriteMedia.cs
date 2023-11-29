using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace FilmsAPI.Data.Entities
{
    public class FavoriteMedia
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int FavoriteMediaId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; } = string.Empty;

        public bool State { get; set; } = true;

        [ForeignKey("UserId")]
        public int UserId { get; set; }
        public User? User { get; set; }
        public string MediaType { get; set; }


        [ForeignKey("MediaId")]
        public int MediaId { get; set; }
        public Media? Media { get; set; }
    }
}
