using MyMenu.DAL.Entities;
using MyMenu.DAL.Interfaces;
using MyMenu.DAL.Repositories;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Threading.Tasks;
using WindowsFormsApp1.Core.Recepies;

namespace WindowsFormsApp1.Core.Servise
{
    public class DataServise : IDataService
    {
        IUnitOfWork Database { get; set; }
        public DataServise(IUnitOfWork uow)
        {
            Database = uow;
        }
        public DataServise()
        {
            Database = new IdentityUnitOfWork("MyMenuContext");
        }

        public async Task Create(ArborioModel arborioModel)
        {
            var recipe = new Recipe()
            {
                Name = arborioModel.Name,
                ImageHref = arborioModel.ImageHref,
                Description = arborioModel.Description,
            };
            var product = new Product();

            RecipeProduct recipeProduct;
            List<Product> products = null;
            var result = Database.RecipeManager.GetRecipeByName(arborioModel.Name);
            if (result.Count == 0)
            {
                try
                {
                    recipe = Database.RecipeManager.Create(recipe);
                }
                catch (DbEntityValidationException e)
                {
                    foreach (var eve in e.EntityValidationErrors)
                    {
                        Debug.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                            eve.Entry.Entity.GetType().Name, eve.Entry.State);
                        foreach (var ve in eve.ValidationErrors)
                        {
                            Debug.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                                ve.PropertyName, ve.ErrorMessage);
                        }
                    }
                    throw;
                }

                for (int i = 0; i < arborioModel.Products.Count; i++)
                {
                    products = Database.ProductManager.FindProductByName(arborioModel.Products[i]);
                    if (products.Count != 0)
                    {
                        recipeProduct = new RecipeProduct()
                        {
                            RecipeId = recipe.RecipeId,
                            ProductId = products[0].ProductId,

                        };
                        if (arborioModel.Units.Count >= i)
                            recipeProduct.Number = arborioModel.Number[i];

                        Database.RecipeProductManager.Create(recipeProduct);
                    }
                    else
                    {
                        product.Name = arborioModel.Products[i];
                        product.Unit = arborioModel.Units[i];
                        Database.ProductManager.Create(product);

                        recipeProduct = new RecipeProduct()
                        {
                            RecipeId = recipe.RecipeId,
                            ProductId = product.ProductId,

                        };
                        recipeProduct.Number = arborioModel.Number[i];
                        Database.RecipeProductManager.Create(recipeProduct);
                    }
                }
                await Database.SaveAsync();
            }

        }

        public void Dispose()
        {
            throw new System.NotImplementedException();
        }
    }
}
