using FilmsAPI.Data.DBContext;
using FilmsAPI.Data.Entities;
using FilmsAPI.Services.Interface;
using Microsoft.AspNetCore.Http.HttpResults;

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

            if (serieToDelete != null)
            {
                serieToDelete.State = false;

                _mediaContext.Update(serieToDelete);
                _mediaContext.SaveChanges();
            }
            else
            {
                //Para cuando serieToDelete es NULL
                Console.WriteLine("La serie no se encontró en la base de datos.");
            }



        }
        public List<Serie> GetAllSeries()

        {

            return _mediaContext.Series.ToList();
        }
        public Serie? GetSerieById(int id)
        {
            return _mediaContext.Series.SingleOrDefault(s => s.MediaId == id);
        }
        public Serie GetSerieByTitle(string title)

        {
            Serie? serie = _mediaContext.Series.SingleOrDefault(s => s.Title == title);

            return serie;

        }
    }
}
