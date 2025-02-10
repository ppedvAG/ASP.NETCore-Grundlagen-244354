using BusinessModel.Models;

namespace BusinessModel.Contracts
{
    public interface IRecipeService
    {
        void Add(Recipe recipe);
        bool Delete(int id);
        List<Recipe> GetAll();
        Recipe? GetById(int id);
        bool Update(Recipe recipe);
    }
}