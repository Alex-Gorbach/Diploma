using DAL.Entities;
using DAL.Interfaces;
using MyMenu.DAL.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class RankManager : IRankManager
    {
        public ApplicationContext Database { get; set; }
        public RankManager(ApplicationContext db)
        {
            Database = db;
        }

        public void Create(Rating item)
        {
            Database.Rating.Add(item);
            Database.SaveChanges();

        }

        public void Dispose()
        {
            Database.Dispose();
        }

        public List<Rating> GetRecipeRanksById(int recipeId)
        {
            var result = Database.Rating.Where(x => x.RecipeId == recipeId).ToList();
            return result;
        }

       
    }
}
