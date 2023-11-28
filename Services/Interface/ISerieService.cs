using FilmsAPI.Data.Entities;

namespace FilmsAPI.Services.Interface
{
    public interface ISerieService
    {

        public int AddSerie(Serie serie);
        void RemoveSerie(int id);
        public List<Serie> GetAllSeries();
        public List<Serie> GetDeletedSeries();

        public Serie? GetSerieById(int id);
        public List<Serie>? GetSeriesByTitle(string title);

    }
}
