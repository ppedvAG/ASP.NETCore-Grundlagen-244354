using MovieStore.Contracts;
using MovieStore.Models;

namespace MovieStore.Services
{
    public class MovieService : IMovieService
    {
        private readonly IList<Movie> _movies =
        [
            new Movie
            {
                Id = 1,
                Title = "The Shawshank Redemption",
                Description = "Two imprisoned men bond over a number of years, finding solace and eventual redemption through acts of common decency.",
                Genre = MovieGenre.Drama,
                Price = 13.99m,
                IMDBRating = 8.5
            },
            new Movie
            {
                Id = 2,
                Title = "The Godfather",
                Description = "The aging patriarch of an organized crime dynasty transfers control of his clandestine empire to his reluctant son.",
                Genre = MovieGenre.Drama,
                Price = 19.99m,
                IMDBRating = 7.6
            },
            new Movie
            {
                Id = 3,
                Title = "Jurassic Park",
                Description = "A pragmatic paleontologist visiting an almost complete theme park is tasked with protecting a couple of kids.",
                Genre = MovieGenre.Adventure,
                Price = 12.99m,
                IMDBRating = 9
            }
        ];

        public IList<Movie> GetMovies()
        {
            return _movies;
        }

        public Movie? GetById(int id)
        {
            return _movies.FirstOrDefault(m => m.Id == id);
        }

        public void AddMovie(Movie movie)
        {
            movie.Id = _movies.Max(m => m.Id) + 1;
            _movies.Add(movie);
        }

        public void UpdateMovie(Movie movie)
        {
            _movies.Remove(movie);
            _movies.Add(movie);
        }

        public void RemoveMovie(Movie movie)
        {
            _movies.Remove(movie);
        }
    }
}
