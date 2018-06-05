using MyMenu.DAL.Entities;
using System;
using System.Collections.Generic;

namespace DAL.Interfaces
{
    public interface IProductManager : IDisposable
    {
        void Create(Product item);
        List<Product> FindProductByName(string productName);
        List<Product> GetProbuctsById(int id);
        List<string> GetProductsCopasity(int id);
        List<Product> GetProductByName(string productName);
        string[] GetProductByHalfName(string val);
    }
}
