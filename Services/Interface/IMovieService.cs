using FilmsAPI.Data.Entities;

namespace FilmsAPI.Services.Interface
{
    public interface IMovieService
    {
        void AddMovieToFavore(Movie movie);
        void RemoveMovieFromFavore(Movie movie);
        public List<Movie> GetAllMovies();
        public List<Movie> GetMovieById(int id);
        public List<Movie> GetMovieByName(string name);
    }
}
