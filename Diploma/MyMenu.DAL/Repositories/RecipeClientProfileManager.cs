using DAL.Entities;
using DAL.Interfaces;
using MyMenu.DAL.EF;

namespace DAL.Repositories
{
    public class RecipeClientProfileManager:IRecipeClientProfileManager
    {
        public ApplicationContext Database { get; set; }
        public RecipeClientProfileManager(ApplicationContext db)
        {
            Database = db;
        }

        public void Create(RecipeClientProfile item)
        {
   
            Database.RecipeClientProfiles.Add(item);
            Database.SaveChanges();

        }

        public void Dispose()
        {
            Database.Dispose();
        }

        public RecipeClientProfile FindByRecipeAndUserId(string userId, int recipeId)
        {
            var result = Database.RecipeClientProfiles.Find( userId,  recipeId);
            return result;
        }
    }
}
