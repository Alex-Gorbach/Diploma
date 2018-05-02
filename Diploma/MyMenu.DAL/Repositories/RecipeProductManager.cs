using System.Collections.Generic;
using System.Linq;
using DAL.Interfaces;
using MyMenu.DAL.EF;
using MyMenu.DAL.Entities;

namespace DAL.Repositories
{
    public class RecipeProductManager:IRecipeProductManager
    {
        public ApplicationContext Database { get; set; }
        public RecipeProductManager(ApplicationContext db)
        {
            Database = db;
        }


        public void Create(RecipeProduct item)
        {
            Database.RecipesProducts.Add(item);
            Database.SaveChanges();

        }

        public void Dispose()
        {
            Database.Dispose();
        }

        public List<RecipeProduct> GetProductIdByRecipe(int recipeId)
        {
            var result = Database.RecipesProducts.Where(x=>x.RecipeId==recipeId).ToList();
            return result;
        }

    }
}
