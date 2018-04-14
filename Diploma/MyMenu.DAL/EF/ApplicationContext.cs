using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using MyMenu.DAL.Entities;

namespace MyMenu.DAL.EF
{
    public class ApplicationContext:IdentityDbContext<ApplicationUser>
    {
        public ApplicationContext(string conectionString) : base(conectionString) { }

        public DbSet<ClientProfile> ClientProfiles { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Recipie> Recipies { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Recipie>().HasMany<Product>(s => s.Products)
                .WithMany(c => c.Recipies).Map(cs =>
                  {
                      cs.MapLeftKey("RecipieId");
                      cs.MapRightKey("ProductId");
                      cs.ToTable("RecipieProduct");
                  });
        }
    }
}
