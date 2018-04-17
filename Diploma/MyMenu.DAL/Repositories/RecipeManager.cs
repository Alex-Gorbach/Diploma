using DAL.Interfaces;
using MyMenu.DAL.EF;
using MyMenu.DAL.Entities;


namespace DAL.Repositories
{
    public class RecipeManager:IRecipeManager
    {
        public ApplicationContext Database { get; set; }
        public RecipeManager(ApplicationContext db)
        {
            Database = db;
        }

        public void Create(Recipe item)
        {
            Database.Recipes.Add(item);
            Database.SaveChanges();

        }

        public void Dispose()
        {
            Database.Dispose();
        }
    }
}
