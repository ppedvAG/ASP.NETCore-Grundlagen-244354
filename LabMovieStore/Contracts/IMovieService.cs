using MovieStore.Models;

namespace MovieStore.Contracts
{
    public interface IMovieService
    {
        void AddMovie(Movie movie);
        Movie? GetById(int id);
        IList<Movie> GetMovies();
        void RemoveMovie(Movie movie);
        void UpdateMovie(Movie movie);
    }
}