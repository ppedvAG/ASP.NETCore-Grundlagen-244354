using BusinessModel.Models;
using DemoMvcApp.Models;

namespace DemoMvcApp.Mappers
{
    public static class RecipesMapper
    {
        // sog. "extension method" welche Recipe erweitert ohne Änderungen an der Klasse vorzunehmen.
        public static RecipesViewModel ToViewModel(this Recipe recipe)
        {
            return new RecipesViewModel
            {
                Id = recipe.Id,
                Name = recipe.Name,
                ImageUrl = recipe.ImageUrl,
                Ingredients = recipe.Ingredients,
                Instructions = recipe.Instructions,
                Rating = recipe.Rating,
                CaloriesPerServing = recipe.CaloriesPerServing,
                CookTimeMinutes = recipe.CookTimeMinutes,
                PrepTimeMinutes = recipe.PrepTimeMinutes,
                Difficulty = recipe.Difficulty,
                MealType = recipe.MealType.FirstOrDefault() ?? string.Empty,
                Tags = recipe.Tags,
            };
        }

        public static Recipe ToDomainModel(this RecipesViewModel model)
        {
            return new Recipe
            {
                Id = model.Id,
                Name = model.Name,
                ImageUrl = model.ImageUrl,
                Ingredients = model.Ingredients,
                Instructions = model.Instructions,
                Rating = model.Rating,
                CaloriesPerServing = model.CaloriesPerServing,
                CookTimeMinutes = model.CookTimeMinutes,
                PrepTimeMinutes = model.PrepTimeMinutes,
                Difficulty = model.Difficulty,
                MealType = [model.MealType],
                Tags = model.Tags,
            };
        }
    }
}
