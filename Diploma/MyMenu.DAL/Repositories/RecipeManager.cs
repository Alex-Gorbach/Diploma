using DAL.Interfaces;
using MyMenu.DAL.EF;
using MyMenu.DAL.Entities;
using System.Collections.Generic;
using System.Linq;


namespace DAL.Repositories
{
    public class RecipeManager:IRecipeManager
    {
        public ApplicationContext Database { get; set; }
        public RecipeManager(ApplicationContext db)
        {
            Database = db;
        }

        public Recipe Create(Recipe item)
        { 
            var result= Database.Recipes.Add(item);
            Database.SaveChanges();
            return result;
        }

        public void Dispose()
        {
            Database.Dispose();
        }

        public List<Recipe> FindRecipeByName(string recipeName)
        {
            var result = Database.Recipes.Where(x=>x.Name == recipeName).ToList();
            return result;
        }

        public List<Recipe> GetAllRepices(int itemsToSkip,int pageSize)
        {
            var result = Database.Recipes.Where(x => x.Name !="")
                .OrderBy(t=>t.RecipeId)
                .Skip(itemsToSkip).Take(pageSize).ToList();
            return result;
        }

        public Recipe GetRecipeById(int id)
        {
            var result = Database.Recipes.Find(id);
            return result;
        }
    }
}
