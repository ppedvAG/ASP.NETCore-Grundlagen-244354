using BusinessLogic.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace DemoMvcApp.Models
{
    public class CreateRecipesViewModel
    {
        [Required]
        public string Name { get; set; }

        public IFormFile? Image { get; set; }

        public string? ImageUrl { get; set; }

        public string? Ingredients { get; set; }

        public string? Instructions { get; set; }

        [Display(Name = "Preperation time in minutes")]
        [Range(0, 120, ErrorMessage = "Preperation time should be between 0 and 120 minutes")]
        public int PrepTimeMinutes { get; set; }

        [Display(Name = "Cooking time in minutes")]
        [Range(0, 120, ErrorMessage = "Cook time should be between 0 and 120 minutes")]
        public int CookTimeMinutes { get; set; }

        public int Servings { get; set; }

        public Difficulty Difficulty { get; set; }

        public string Cuisine { get; set; }

        [Display(Name = "Calories per serving")]
        public int CaloriesPerServing { get; set; }

        public string? Tags { get; set; }

        public float Rating { get; set; }

        [Display(Name = "Meal type")]
        public string MealType { get; set; }
    }
}
