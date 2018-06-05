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
            var result = Database.Products.Where(x => x.Name == productName).ToList();
            return result;
        }


        public List<Product> GetProbuctsById(int recipeId)
        {
            var productsList = new List<Product>();
            var productsId = new List<int>();
            var recipeProduct = new RecipeProductManager(Database);
            var recipeProductList= recipeProduct.GetProductIdByRecipe(recipeId);
            foreach (var item in recipeProductList)
            {
                productsId.Add(item.ProductId);
            }
          
            for (int i = 0; i < productsId.Count; i++)
            {
                int index = productsId.ElementAt(i);
                var result = Database.Products.Where(x => x.ProductId == index).ToList();
                foreach (var item in result)
                {
                    productsList.Add(item);
                }
            }
           
            return productsList;
        }

        public List<string> GetProductsCopasity(int id)
        {
            var productCopasity = new List<string>();
            var recipeProduct = new RecipeProductManager(Database);
            var productId = recipeProduct.GetProductIdByRecipe(id);
            foreach (var item in productId)
            {
                productCopasity.Add(item.Number);
            }
            return productCopasity;
        }

        public List<Product> GetProductByName(string productName)
        {
            var result = Database.Products.Where(x => x.Name == productName).ToList();
            return result;
        }

        public string[] GetProductByHalfName(string val)
        {
            var result = (from x in Database.Products where x.Name.Contains(val) select x.Name).ToArray();
            return result;
        }
    }

}
