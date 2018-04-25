using DAL.Interfaces;
using MyMenu.DAL.EF;
using MyMenu.DAL.Entities;
using System.Collections.Generic;
using System.Linq;

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

        public List<Product> FindProductByName(string productName)
        {
            var list = new List<Product>();
            var result = Database.Products.Where(x => x.Name == productName);
            foreach (var item in result)
            {
                list.Add(item);
            }
            return list;
        }
    }

}
