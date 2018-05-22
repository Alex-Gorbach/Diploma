using DAL.Entities;
using System;
using System.Collections.Generic;

namespace DAL.Interfaces
{
    public interface IRecipeClientProfileManager:IDisposable
    {
        void Create(RecipeClientProfile item);
        RecipeClientProfile FindByRecipeAndUserId(string userId, int recipeId);
        List<RecipeClientProfile> FindRecipesByUserId(string userId);
        void Remove(RecipeClientProfile recipeUser);
    }
}
