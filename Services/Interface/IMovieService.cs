using FilmsAPI.Data.Entities;

namespace FilmsAPI.Services.Interface
{
    public interface IMovieService
    {

        public int AddMovie(Movie movie);
        void RemoveMovie(int id);
        public List<Movie> GetAllMovies();
        public Movie? GetMovieById(int id);
        public Movie? GetMovieByTitle(string title);
    }
}
