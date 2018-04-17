using MyMenu.DAL.Entities;
using System;
namespace DAL.Interfaces
{
    public interface IProductManager : IDisposable
    {
        void Create(Product item);
    }
}
