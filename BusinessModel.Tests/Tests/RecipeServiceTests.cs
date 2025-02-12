using BusinessLogic.Models.Enums;
using BusinessModel.Contracts;
using BusinessModel.Data;
using BusinessModel.Models;
using BusinessModel.Services;
using Microsoft.Extensions.Options;
using Moq;

namespace BusinessModel.Tests.Tests
{
    [TestClass]
    public class RecipeServiceTests
    {
        private readonly Mock<IFileService> _mockFileService = new Mock<IFileService>();
        private DeliveryDbContext _context;

        public IFileService FileService => _mockFileService.Object;

        [TestInitialize]
        public void Setup()
        {
            _context = new TestDatabase().Context;
        }

        [TestCleanup]
        public async Task Cleanup()
        {
            await _context.DisposeAsync();
        }

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
            var recipeService = new RecipeService(_context, FileService);

            // Act
            var result = await recipeService.GetAll();

            // Assert
            Assert.IsNotNull(result, "Die Liste mit Rezepten sollte nicht null sein.");
            Assert.IsTrue(result.Count > 0, "Die Liste mit Rezepten sollte nicht leer sein.");
            Assert.IsTrue(result[0].MealType.Length > 0, "Das erste Rezept sollte einen MealTyp haben.");
        }

        [TestMethod]
        public async Task GetAll_SecondPage_ReturnsListOfRecipes()
        {
            // Arrange
            int pageIndex = 2;
            int pageSize = 10;
            int expectedRecipeId = 11;
            var expectedRecipeIds = new int[] { 11, 12, 13, 14, 15, 16, 17, 18, 19, 20 };
            var recipeService = new RecipeService(_context, FileService);

            // Act
            var result = await recipeService.GetAll(pageIndex, pageSize);

            // Assert
            Assert.IsNotNull(result, "Die Liste mit Rezepten sollte nicht null sein.");
            Assert.AreEqual(pageSize, result.Count, "Die Liste mit Rezepten sollte 10 Items haben.");
            Assert.AreEqual(expectedRecipeId, result[0].Id, $"Die RecipeId sollte {expectedRecipeId} sein.");

            var actualRecipeIds = result.Select(r => r.Id).ToArray();
            CollectionAssert.AreEquivalent(expectedRecipeIds, actualRecipeIds);
        }

        [TestMethod]
        public async Task GetById_ExistingId_ReturnsRecipe()
        {
            // Arrange
            var recipeService = new RecipeService(_context, FileService);

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
            string expectedName = "Test Recipe";
            var recipeService = new RecipeService(_context, FileService);
            var newRecipe = new Recipe 
            { 
                Name = expectedName, 
                MealType = [MealType.Snack.ToString()],
                Cuisine = Cuisine.Indian.ToString(),
                ImageUrl = "https://example.com/test-recipe.jpg",
                Ingredients = [],
                Instructions = [],
                Tags = [],
            };

            // Act
            await recipeService.Add(newRecipe);
            var result = _context.Recipes.Any(r => r.Name == expectedName);

            // Assert
            Assert.IsTrue(result, "Das neue Rezept sollte in der Liste sein.");
        }

        [TestMethod]
        public async Task Add_NewRecipeWithImage_IncreasesRecipeCount()
        {
            // Arrange
            string expectedName = "Test Recipe";
            string fileName = "test-image.jpg";
            var stream = new MemoryStream();

            _mockFileService
                .Setup(x => x.UploadFile(fileName, It.IsAny<Stream>()))
                // Alternative: Beliebigen FileName als Argument akzeptieren mit It.IsAny<string>()
                //.Setup(x => x.UploadFile(It.IsAny<string>(), It.IsAny<Stream>()))
                .ReturnsAsync($"https://example.com/files/{fileName}");

            var recipeService = new RecipeService(_context, FileService);
            var newRecipe = new Recipe 
            { 
                Name = expectedName, 
                MealType = [MealType.Snack.ToString()],
                Cuisine = Cuisine.Indian.ToString(),
                Ingredients = [],
                Instructions = [],
                Tags = [],
            };

            // Act
            await recipeService.AddWithImage(newRecipe, stream, fileName);
            var result = _context.Recipes.Any(r => r.Name == expectedName);

            // Assert
            Assert.IsTrue(result, "Das neue Rezept sollte in der Liste sein.");
            _mockFileService.Verify(x => x.UploadFile(fileName, stream), Times.Once, "Die Datei sollte hochgeladen werden.");
        }

        [TestMethod]
        public async Task Add_InvalidFileServiceUrl_ThrowsRemoteUploadFileException()
        {
            // Arrange
            var options = new Mock<IOptions<FileServiceOptions>>();
            options.Setup(x => x.Value).Returns(new FileServiceOptions 
            { 
                BaseUrl = "https://example.com" 
            });

            var fileService = new RemoteFileService(options.Object, new HttpClient());
            var recipeService = new RecipeService(_context, fileService);

            // Act
            var task = recipeService.AddWithImage(new Recipe(), new MemoryStream(), "abc");

            // Assert
            var ex = await Assert.ThrowsExceptionAsync<RemoteUploadFileException>(async () => await task);
            Assert.IsTrue(ex.Message.StartsWith("File could not be uploaded."));
        }

        [TestMethod]
        public async Task Update_ExistingRecipe_UpdatesRecipeDetails()
        {
            // Arrange
            var recipeService = new RecipeService(_context, FileService);
            var existingRecipe = _context.Recipes.First();
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
            var recipeService = new RecipeService(_context, FileService);
            var existingRecipe = _context.Recipes.First();

            // Act
            var deleteResult = await recipeService.Delete(existingRecipe.Id);
            var result = await recipeService.GetAll();

            // Assert
            Assert.IsTrue(deleteResult, "Das Rezept sollte erfolgreich gelöscht werden.");
            Assert.IsFalse(result.Any(r => r.Id == existingRecipe.Id), "Das Rezept sollte nicht mehr in der Liste sein.");
        }
    }
}
