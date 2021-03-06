﻿using MyMenu.DAL.Entities;
using MyMenu.DAL.Interfaces;
using MyMenu.DAL.Repositories;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WindowsFormsApp1.Core.Recepies;

namespace WindowsFormsApp1.Core.Servise
{
    public class DataServise : IDataService
    {
        IUnitOfWork Database { get; set; }
        public DataServise( IUnitOfWork uow )
        {
            Database = uow;
        }
        public DataServise()
        {
            Database = new IdentityUnitOfWork("MyMenuContext");
        }

        public async Task Create( ArborioModel arborioModel )
        {
            var recipe = new Recipe()
            {
                Name = arborioModel.Name,
                ImageHref = arborioModel.ImageHref,
                Description = arborioModel.Description,
            };
            var product = new Product();

            RecipeProduct recipeProduct;
            Product productFind = null;
            var result = Database.RecipeManager.GetRecipeByName( arborioModel.Name );
            if (result.Count == 0)
            {
                try
                {
                    recipe = Database.RecipeManager.Create( recipe );
                }
                catch (DbEntityValidationException e)
                {
                    foreach (var eve in e.EntityValidationErrors)
                    {
                        Debug.WriteLine( "Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                            eve.Entry.Entity.GetType().Name, eve.Entry.State );
                        foreach (var ve in eve.ValidationErrors)
                        {
                            Debug.WriteLine( "- Property: \"{0}\", Error: \"{1}\"",
                                ve.PropertyName, ve.ErrorMessage );
                        }
                    }
                    throw;
                }

                for (int i = 0; i < arborioModel.Products.Count; i++)
                {
                    productFind = Database.ProductManager.FindProductByName( arborioModel.Products[i] );
                    if (productFind != null)
                    {
                        recipeProduct = new RecipeProduct()
                        {
                            RecipeId = recipe.RecipeId,
                            ProductId = productFind.ProductId,
                        };
                        var res = Database.RecipeProductManager.GetRecipeIdByProductId( productFind.ProductId );
                        var recipeRes = res.Where( x => x.RecipeId == recipe.RecipeId );
                        if (recipeRes.Count() == 0)
                        {
                            recipeProduct.Number = arborioModel.Number[i];
                            Database.RecipeProductManager.Create( recipeProduct );
                        }
                        else
                        {
                            var ds = 5;
                        }

                    }
                    else
                    {
                        product.Name = arborioModel.Products[i];
                        Database.ProductManager.Create( product );

                        recipeProduct = new RecipeProduct()
                        {
                            RecipeId = recipe.RecipeId,
                            ProductId = product.ProductId,

                        };
                        recipeProduct.Number = arborioModel.Number[i];
                        Database.RecipeProductManager.Create( recipeProduct );
                    }
                    await Database.SaveAsync();
                }

            }

        }

        public void Dispose()
        {
            throw new System.NotImplementedException();
        }
    }
}
