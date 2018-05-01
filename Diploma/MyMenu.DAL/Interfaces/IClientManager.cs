using MyMenu.DAL.Entities;
using System;

namespace MyMenu.DAL.Interfaces
{
    public interface IClientManager : IDisposable
    {
        void Create(ClientProfile item);
       
    }
}
