using FilmsAPI.Data.DBContext;
using FilmsAPI.Data.Entities;
using FilmsAPI.Services.Interface;

namespace FilmsAPI.Services.Implementations
{
    public class SerieService : ISerieService
    {

        private readonly MediaContext _mediaContext;

        public SerieService(MediaContext mediaContext)
        {
            _mediaContext = mediaContext;
        }



        public int AddSerie(Serie serie)
        {
            _mediaContext.Add(serie);
            _mediaContext.SaveChanges();

            return serie.MediaId;
        }
        public void RemoveSerie(int id)
        {
            Serie? serieToDelete = _mediaContext.Series.FirstOrDefault(s => s.MediaId == id);


            serieToDelete.State = false;

            _mediaContext.Update(serieToDelete);
            _mediaContext.SaveChanges();
        }
        public List<Serie> GetAllSeries()

        {
            return _mediaContext.Series.Where(s=> s.State).ToList();
        }

        public List<Serie> GetDeletedSeries()
        {
            return _mediaContext.Series.Where(s => !s.State).ToList();
        }

        public Serie? GetSerieById(int id)
        {
            return _mediaContext.Series.SingleOrDefault(s => s.MediaId == id);
        }
        public List<Serie> GetSeriesByTitle(string title)

        {
            List<Serie>? serie = _mediaContext.Series.Where(s => s.Title.Contains(title) && s.State).ToList(); ;

            return serie;

        }
    }
}
