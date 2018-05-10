using MyMenu.DAL.Entities;
using System;
using System.Collections.Generic;

namespace DAL.Interfaces
{
    public interface IRecipeManager:IDisposable
    {
        Recipe Create(Recipe item);
        List<Recipe> GetRecipeByName(string recipeName);
        List<Recipe> GetAllRepices(int itemsToSkip,int pageSize);
        Recipe GetRecipeById(int id);
    }
}
