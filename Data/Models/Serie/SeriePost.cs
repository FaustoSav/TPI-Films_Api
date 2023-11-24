namespace FilmsAPI.Data.Models.Serie
{
    public class SeriePost
    {
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Genre { get; set; }

        public int Seasons { get; set; }
        public int Episodes { get; set; }
    }
}
