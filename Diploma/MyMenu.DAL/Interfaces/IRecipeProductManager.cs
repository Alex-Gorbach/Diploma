using MyMenu.DAL.Entities;
using System;

namespace DAL.Interfaces
{
    public interface IRecipeProductManager:IDisposable
    {
        void Create(RecipeProduct item);
    }
}
