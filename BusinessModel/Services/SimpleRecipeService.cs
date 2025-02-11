using BusinessModel.Contracts;
using BusinessModel.Data;
using BusinessModel.Models;

namespace BusinessModel.Services
{
    /// <summary>
    /// Service welcher den Datenbankzugriff abbilden soll, vgl. <see cref="https://de.wikipedia.org/wiki/Repository_(Entwurfsmuster)"/>
    /// Dieser Service bildet CRUD Operationen auf die Rezepte ab.
    /// </summary>
    public class SimpleRecipeService : IRecipeService
    {
        private readonly List<Recipe> _recipes = RecipeReader.FromJsonFile() ?? new List<Recipe>();

        public List<Recipe> GetAll()
        {
            return _recipes;
        }

        public Recipe? GetById(int id)
        {
            return _recipes.SingleOrDefault(r => r.Id == id);
        }

        public void Add(Recipe recipe)
        {
            _recipes.Insert(0, recipe);
        }

        public bool Update(Recipe recipe)
        {
            var index = _recipes.FindIndex(r => r.Id == recipe.Id);
            if (index > 0)
            {
                _recipes[index] = recipe;
                return true;
            }
            return false;
        }

        public bool Delete(int id)
        {
            var index = _recipes.FindIndex(r => r.Id == id);
            if (index > 0)
            {
                _recipes.RemoveAt(index);
                return true;
            }
            return false;
        }
    }

}
