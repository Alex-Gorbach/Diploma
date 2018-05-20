using DAL.Entities;
using System;

namespace DAL.Interfaces
{
    public interface IRecipeClientProfileManager:IDisposable
    {
        void Create(RecipeClientProfile item);
        RecipeClientProfile FindByRecipeAndUserId(string userId, int recipeId);
    }
}
