using BusinessModel.Models;

namespace BusinessModel.Contracts
{
    public interface IRecipeServiceAsync
    {
        Task Add(Recipe recipe);
        Task<bool> Delete(int id);
        Task<List<Recipe>> GetAll();
        Task<Recipe?> GetById(int id);
        Task<bool> Update(Recipe recipe);
    }
}