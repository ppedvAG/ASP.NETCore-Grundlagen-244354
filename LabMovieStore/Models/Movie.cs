namespace MovieStore.Models
{
    public class Movie
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public double IMDBRating { get; set; }
        public MovieGenre Genre { get; set; }
    }
}
