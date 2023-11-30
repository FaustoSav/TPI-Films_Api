using FilmsAPI.Data.DBContext;
using FilmsAPI.Data.Entities;
using FilmsAPI.Data.Enum;
using FilmsAPI.Services.Interface;
using Microsoft.EntityFrameworkCore;

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



            movieToDelete.State = false;

            _mediaContext.Update(movieToDelete);
            _mediaContext.SaveChanges();


        }
        public List<Movie> GetAllMovies()

        {
            return _mediaContext.Movies.Where(m => m.State).ToList();
        }
        public List<Movie> GetDeletedMovies()
        {
            return _mediaContext.Movies.Where(m => !m.State).ToList();
        }
        public Movie? GetMovieById(int id)
        {
            return _mediaContext.Movies.SingleOrDefault(m => m.MediaId == id && m.State);
        }
        public List<Movie> GetMoviesByTitle(string title)

        {

            List<Movie>? movie = _mediaContext.Movies.Where(m => m.Title.ToLower().Contains(title.ToLower()) && m.State).ToList();
            return movie;

        }
    }
}
