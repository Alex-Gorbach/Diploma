using MyMenu.DAL.Entities;
using System;

namespace DAL.Interfaces
{
    public interface IRecipeManager:IDisposable
    {
        void Create(Recipe item);
    }
}
