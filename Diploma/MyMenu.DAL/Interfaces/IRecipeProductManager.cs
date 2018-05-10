using MyMenu.DAL.Entities;
using System;
using System.Collections.Generic;

namespace DAL.Interfaces
{
    public interface IRecipeProductManager:IDisposable
    {
        void Create(RecipeProduct item);
        List<RecipeProduct> GetProductIdByRecipe(int recipeId);
        IEnumerable<RecipeProduct> GetRecipeIdByProductId(int productId);
    }
}
