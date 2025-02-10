using BusinessLogic.Models.Enums;
using System.Diagnostics;
using System.Text.Json.Serialization;

namespace BusinessModel.Models
{
    [DebuggerDisplay("{Id}, {Name}, {Difficulty}, {Cuisine}, {CaloriesPerServing}, {Rating}, {Tags}")]
    public class Recipe
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string[] Ingredients { get; set; }
        public string[] Instructions { get; set; }
        public int PrepTimeMinutes { get; set; }
        public int CookTimeMinutes { get; set; }
        public int Servings { get; set; }
        public Difficulty Difficulty { get; set; }
        public string Cuisine { get; set; }
        public int CaloriesPerServing { get; set; }
        public string[] Tags { get; set; }
        public int UserId { get; set; }

        [JsonPropertyName("image")]
        public string ImageUrl { get; set; }
        public float Rating { get; set; }
        public int ReviewCount { get; set; }
        public string[] MealType { get; set; }
    }
}
