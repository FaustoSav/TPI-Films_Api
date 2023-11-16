namespace FilmsAPI.Data.Entities
{
    public class FavoriteSerie
    {
        public int UserId { get; set; }
        public User User { get; set; }

        public int SerieId { get; set; }
        public Serie Serie { get; set; }
    }
}
