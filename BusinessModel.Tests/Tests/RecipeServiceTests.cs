using BusinessLogic.Models.Enums;
using BusinessModel.Models;
using BusinessModel.Services;

namespace BusinessModel.Tests.Tests
{
    [TestClass]
    public class RecipeServiceTests
    {

        /// <summary>
        /// Benamung: ZuTestendeMethode_Szenario_ErwartetesErgebnis
        /// </summary>
        [TestMethod]
        public void GetAll_Default_ReturnsListOfRecipes()
        {
            // Arrange
            var recipeService = new SimpleRecipeService();

            // Act
            var result = recipeService.GetAll();

            // Assert
            Assert.IsNotNull(result, "Die Liste mit Rezepten sollte nicht null sein.");
            Assert.IsTrue(result.Count > 0, "Die Liste mit Rezepten sollte nicht leer sein.");
            Assert.IsTrue(result[0].MealType.Length > 0, "Das erste Rezept sollte einen MealTyp haben.");
        }

        [TestMethod]
        public async Task GetAll_LoadFromDatabase_ReturnsListOfRecipes()
        {
            // Arrange
            using var context = new TestDatabase().Context;
            var recipeService = new RecipeService(context);

            // Act
            var result = await recipeService.GetAll();

            // Assert
            Assert.IsNotNull(result, "Die Liste mit Rezepten sollte nicht null sein.");
            Assert.IsTrue(result.Count > 0, "Die Liste mit Rezepten sollte nicht leer sein.");
            Assert.IsTrue(result[0].MealType.Length > 0, "Das erste Rezept sollte einen MealTyp haben.");
        }

        [TestMethod]
        public async Task GetById_ExistingId_ReturnsRecipe()
        {
            // Arrange
            using var context = new TestDatabase().Context;
            var recipeService = new RecipeService(context);

            // Act
            var result = await recipeService.GetById(1);

            // Assert
            Assert.IsNotNull(result, "Das Rezept sollte nicht null sein.");
            Assert.AreEqual(1, result.Id, "Das zurückgegebene Rezept sollte die gleiche ID haben.");
        }

        [TestMethod]
        public async Task Add_NewRecipe_IncreasesRecipeCount()
        {
            // Arrange
            using var context = new TestDatabase().Context;
            var recipeService = new RecipeService(context);
            var newRecipe = new Recipe 
            { 
                Name = "Test Recipe", 
                MealType = [MealType.Snack.ToString()],
                Cuisine = Cuisine.Indian.ToString(),
                ImageUrl = "https://example.com/test-recipe.jpg",
                Ingredients = [],
                Instructions = [],
                Tags = [],
            };

            // Act
            await recipeService.Add(newRecipe);
            var result = await recipeService.GetAll();

            // Assert
            Assert.IsTrue(result.Any(r => r.Name == "Test Recipe"), "Das neue Rezept sollte in der Liste sein.");
        }

        [TestMethod]
        public async Task Update_ExistingRecipe_UpdatesRecipeDetails()
        {
            // Arrange
            using var context = new TestDatabase().Context;
            var recipeService = new RecipeService(context);
            var existingRecipe = context.Recipes.First();
            existingRecipe.Name = "Updated Recipe Name";

            // Act
            var updateResult = await recipeService.Update(existingRecipe);
            var updatedRecipe = await recipeService.GetById(existingRecipe.Id);

            // Assert
            Assert.IsTrue(updateResult, "Das Rezept sollte erfolgreich aktualisiert werden.");
            Assert.AreEqual("Updated Recipe Name", updatedRecipe.Name, "Der Name des Rezepts sollte aktualisiert sein.");
        }

        [TestMethod]
        public async Task Delete_ExistingRecipe_RemovesRecipeFromDatabase()
        {
            // Arrange
            using var context = new TestDatabase().Context;
            var recipeService = new RecipeService(context);
            var existingRecipe = context.Recipes.First();

            // Act
            var deleteResult = await recipeService.Delete(existingRecipe.Id);
            var result = await recipeService.GetAll();

            // Assert
            Assert.IsTrue(deleteResult, "Das Rezept sollte erfolgreich gelöscht werden.");
            Assert.IsFalse(result.Any(r => r.Id == existingRecipe.Id), "Das Rezept sollte nicht mehr in der Liste sein.");
        }
    }
}
