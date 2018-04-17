using DAL.Interfaces;
using MyMenu.DAL.EF;
using MyMenu.DAL.Entities;


namespace DAL.Repositories
{
    public class ProductManager:IProductManager
    {
        public ApplicationContext Database { get; set; }
        public ProductManager(ApplicationContext db)
        {
            Database = db;
        }

        public void Create(Product item)
        {
            Database.Products.Add(item);
            Database.SaveChanges();

        }

        public void Dispose()
        {
            Database.Dispose();
        }
    }

}
