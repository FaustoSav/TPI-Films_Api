using FilmsAPI.Data.Entities;

namespace FilmsAPI.Services.Interface
{
    public interface ISerieService
    {

        void AddSerie(Serie serie);
        void RemoveSerie(Serie serie);
        public List<Serie> GetAllSeries();
        public List<Serie> GetSerieById(int id);
        public List<Serie> GetSerieByName(string name);

    }
}
