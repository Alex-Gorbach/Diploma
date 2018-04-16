using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using MyMenu.DAL.Entities;

namespace MyMenu.DAL.EF
{
    public class ApplicationContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationContext(string conectionString) : base("MyMenyContext") { }

        public DbSet<ClientProfile> ClientProfiles { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Recipie> Recipies { get; set; }
        public DbSet<RecipieProduct> RecipiesProducts { get; set; }
       
    }
}
