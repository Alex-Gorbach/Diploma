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
            var list = new List<Recipe>();
            var result = Database.Recipes.Where(x=>x.Name == recipeName);
            foreach (var item in result)
            {
                list.Add(item);
            }
            return list;
        }

        public List<Recipe> GetAllRepicesName()
        {
            var list = new List<Recipe>();
            var rusult = Database.Recipes.Where(x => x.Name!="");
            foreach (var item in rusult)
            {
                list.Add(item);
            }
            return list;
        }
    }
}
