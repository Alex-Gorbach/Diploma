using System.Data.Entity;
using DAL.Entities;
using Microsoft.AspNet.Identity.EntityFramework;
using MyMenu.DAL.Entities;

namespace MyMenu.DAL.EF
{
    public class ApplicationContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationContext(string conectionString) : base("MyMenuContext") { }

        public DbSet<ClientProfile> ClientProfiles { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<RecipeProduct> RecipesProducts { get; set; }
        public DbSet<RecipeClientProfile> RecipeClientProfiles { get; set; }

    }

}
