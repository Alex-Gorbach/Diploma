using MyMenu.DAL.Entities;
using System;
using System.Collections.Generic;

namespace DAL.Interfaces
{
    public interface IProductManager : IDisposable
    {
        void Create(Product item);
        Product FindProductByName(string productName);
        List<Product> GetProbuctsById(int id);
        List<string> GetProductsCopasity(int id);
<<<<<<< HEAD
        List<Product> GetProductByName(string productName);
        string[] GetProductByHalfName(string val);
=======
        Product GetProductByName(string productName);
>>>>>>> 8a282ff13e5b32d821ea932e9db606234c1168ef
    }
}
