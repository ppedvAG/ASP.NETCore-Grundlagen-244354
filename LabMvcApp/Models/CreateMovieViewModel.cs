using MovieStore.Models;
using System.ComponentModel.DataAnnotations;

namespace LabMvcApp.Models
{
    public class CreateMovieViewModel
    {
        [Required(ErrorMessage = "Bitte Titel eingeben")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Bitte Beschreibung eingeben")]
        public string Description { get; set; }

        [Range(0, 9999, ErrorMessage = "Bitte mindestens 0 eingeben")]
        public decimal Price { get; set; }

        [Range(0, 10, ErrorMessage = "Bitte Bewertung zwischen 0 und 10 eingeben")]
        public double IMDBRating { get; set; }

        [Required(ErrorMessage = "Bitte Genre auswaehlen")]
        public MovieGenre Genre { get; set; }

        public IFormFile? Image { get; set; }
    }
}
