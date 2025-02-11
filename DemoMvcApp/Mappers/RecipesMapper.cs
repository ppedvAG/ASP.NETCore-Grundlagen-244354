using BusinessModel.Models;
using DemoMvcApp.Models;
using System.Text;

namespace DemoMvcApp.Mappers
{
    /// <summary>
    /// Die ViewModels koennen grundsaetzlich anders aussehen als die DomainModels.
    /// Die Mappers transformieren die Daten in das gewuenschte Format.
    /// Per Konvention sollten alle DomainModels in ViewModels umgewandelt werden und zurueck.
    /// </summary>
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

        public static EditRecipesViewModel ToEditModel(this Recipe recipe)
        {
            var ingredients = recipe.Ingredients.Aggregate(new StringBuilder(), (sb, current) => sb.AppendLine(current));
            var instructions = recipe.Instructions.Aggregate(new StringBuilder(), (sb, current) => sb.AppendLine(current));
            var tags = recipe.Tags.Aggregate(new StringBuilder(), (sb, current) => sb.Append(current + ","));

            return new EditRecipesViewModel
            {
                Id = recipe.Id,
                Name = recipe.Name,
                ImageUrl = recipe.ImageUrl,
                Ingredients = ingredients.ToString(),
                Instructions = instructions.ToString(),
                Rating = recipe.Rating,
                CaloriesPerServing = recipe.CaloriesPerServing,
                CookTimeMinutes = recipe.CookTimeMinutes,
                PrepTimeMinutes = recipe.PrepTimeMinutes,
                Difficulty = recipe.Difficulty,
                MealType = recipe.MealType.FirstOrDefault() ?? string.Empty,
                Tags = tags.ToString(),
            };
        }

        public static Recipe ToDomainModel(this CreateRecipesViewModel model)
        {
            return new Recipe
            {
                Name = model.Name,
                ImageUrl = model.ImageUrl,
                Ingredients = model.Ingredients?.Split(Environment.NewLine) ?? [],
                Instructions = model.Instructions?.Split(Environment.NewLine) ?? [],
                Rating = model.Rating,
                CaloriesPerServing = model.CaloriesPerServing,
                CookTimeMinutes = model.CookTimeMinutes,
                PrepTimeMinutes = model.PrepTimeMinutes,
                Difficulty = model.Difficulty,
                MealType = [model.MealType],
                Tags = model.Tags?.Split(',') ?? [],
            };
        }
    }
}
