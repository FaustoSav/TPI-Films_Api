using FilmsAPI.Data.DBContext;
using FilmsAPI.Data.Entities;
using FilmsAPI.Data.Enum;
using FilmsAPI.Services.Interface;

namespace FilmsAPI.Services.Implementations
{
    public class MovieService : IMovieService
    {
        private readonly MediaContext _mediaContext;

        public MovieService(MediaContext mediaContext)
        {
            _mediaContext = mediaContext;
        }



        public int AddMovie(Movie movie)
        {
            _mediaContext.Add(movie);
            _mediaContext.SaveChanges();

            return movie.MediaId;
        }
        public void RemoveMovie(int id)
        {
            Movie? movieToDelete = _mediaContext.Movies.FirstOrDefault(s => s.MediaId == id);

            if (movieToDelete != null)
            {
                movieToDelete.State = false;

                _mediaContext.Update(movieToDelete);
                _mediaContext.SaveChanges();
            }
            else
            {
                //Para cuando movieToDelete es NULL
                Console.WriteLine("La serie no se encontró en la base de datos.");
            }



        }
        public List<Movie> GetAllMovies()

        {

            return _mediaContext.Movies.ToList();
        }
        public Movie? GetMovieById(int id)
        {
            return _mediaContext.Movies.SingleOrDefault(m => m.MediaId == id);
        }
        public Movie GetMovieByTitle(string title)

        {

            Movie? movie = _mediaContext.Movies.SingleOrDefault(m => m.Title == title);
            return movie;

        }
    }
}
