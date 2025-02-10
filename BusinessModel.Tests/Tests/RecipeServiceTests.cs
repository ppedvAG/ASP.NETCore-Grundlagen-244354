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

        // Hier koennten noch weitere Testszenarien ergaenzt werden fuer alle Methoden
        // Gut- als auch schlechter Testfall, z. B. Test mit gueltiger als auch ungueltiger Id
    }
}
