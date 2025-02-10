using BusinessModel.Data;

namespace BusinessModel.Tests.Tests
{
    [TestClass]
    public sealed class RecipeReaderTests
    {
        /// <summary>
        /// Benamung: ZuTestendeMethode_Szenario_ErwartetesErgebnis
        /// </summary>
        [TestMethod]
        public void FromJsonFile_ReadFromFile_ReturnsListOfRecipes()
        {
            var result = RecipeReader.FromJsonFile();

            // Assert
            Assert.IsNotNull(result, "Die Liste mit Rezepten sollte nicht null sein.");
            Assert.IsTrue(result.Count > 0, "Die Liste mit Rezepten sollte nicht leer sein.");
            Assert.IsTrue(result[0].MealType.Length > 0, "Das erste Rezept sollte einen MealTyp haben.");
        }
    }
}
