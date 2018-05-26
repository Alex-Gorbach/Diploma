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

        public List<Recipe> GetRecipeByName(string recipeName)
        {
            var result = Database.Recipes.Where(x=>x.Name.Contains(recipeName)).ToList();
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

        public void UpdateRank(int recipeId, double resultRecipeRank)
        {
            var recipe = new Recipe() {RecipeId=recipeId, Rank = resultRecipeRank };
            Database.Recipes.Attach(recipe);
            Database.Entry(recipe).Property(x => x.Rank).IsModified = true;
            Database.SaveChanges();
        }

        public List<Recipe> GetTopFiveRanked()
        {
            var recipes = (from x in Database.Recipes orderby x.Rank select x).Take(5).ToList();
            var result = (from r in recipes orderby r.Rank descending select r).ToList();
            return result;
        }
    }
}
