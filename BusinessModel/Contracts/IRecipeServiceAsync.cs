using BusinessModel.Models;

namespace BusinessModel.Contracts
{
    public interface IRecipeServiceAsync
    {
        Task Add(Recipe recipe);
        Task AddWithImage(Recipe recipe, Stream stream, string fileName);

        Task<bool> Delete(int id);
        Task<PaginatedList<Recipe>> GetAll(int pageIndex, int pageSize = 20);
        Task<Recipe?> GetById(int id);
        Task<bool> Update(Recipe recipe);
    }
}