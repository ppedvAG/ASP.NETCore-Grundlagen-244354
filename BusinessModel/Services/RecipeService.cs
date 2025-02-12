using BusinessModel.Contracts;
using BusinessModel.Data;
using BusinessModel.Models;
using Microsoft.EntityFrameworkCore;

namespace BusinessModel.Services
{
    public class RecipeService : IRecipeServiceAsync
    {
        private readonly DeliveryDbContext _context;

        public RecipeService(DeliveryDbContext context)
        {
            _context = context;
        }

        public async Task<List<Recipe>> GetAll()
        {
            return await _context.Recipes.ToListAsync();
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
