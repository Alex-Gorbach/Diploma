using MyMenu.DAL.Entities;
using System;
using System.Collections.Generic;

namespace DAL.Interfaces
{
    public interface IRecipeManager:IDisposable
    {
        Recipe Create(Recipe item);
        List<Recipe> FindRecipeByName(string recipeName);
        List<Recipe> GetAllRepicesName();
    }
}
