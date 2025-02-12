using BusinessModel.Contracts;
using BusinessModel.Data;
using BusinessModel.Models;
using Microsoft.EntityFrameworkCore;

namespace BusinessModel.Services
{
    public class RecipeService : IRecipeServiceAsync
    {
        private readonly DeliveryDbContext _context;
        private readonly IFileService _fileService;

        public RecipeService(DeliveryDbContext context, IFileService fileService)
        {
            _context = context;
            _fileService = fileService;
        }

        public async Task<PaginatedList<Recipe>> GetAll(int pageIndex = 1, int pageSize = 20)
        {
            var count = await _context.Recipes.CountAsync();
            var items = await _context.Recipes
                .Skip((pageIndex - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return new PaginatedList<Recipe>(items, count, pageSize)
            {
                PageIndex = pageIndex
            };
        }

        public async Task<Recipe?> GetById(int id)
        {
            return await _context.Recipes.FindAsync(id);
        }

        public async Task Add(Recipe recipe)
        {
            await _context.Recipes.AddAsync(recipe);
            await _context.SaveChangesAsync();
        }

        public async Task AddWithImage(Recipe recipe, Stream stream, string fileName)
        {
            recipe.ImageUrl = await _fileService.UploadFile(fileName, stream);
            await Add(recipe);
        }

        public async Task<bool> Update(Recipe recipe)
        {
            var existingRecipe = await _context.Recipes.FindAsync(recipe.Id);
            if (existingRecipe != null)
            {
                _context.Entry(existingRecipe).CurrentValues.SetValues(recipe);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<bool> Delete(int id)
        {
            var recipe = await _context.Recipes.FindAsync(id);
            if (recipe != null)
            {
                _context.Recipes.Remove(recipe);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}
