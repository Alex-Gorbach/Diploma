using DAL.Interfaces;
using MyMenu.DAL.Identity;
using System;
using System.Threading.Tasks;

namespace MyMenu.DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        ApplicationUserManager UserManager { get; }
        IClientManager ClientManager { get; }
        IProductManager ProductManager { get; }
        IRecipeManager RecipeManager { get; }
        IRecipeProductManager RecipeProductManager { get; }
        IRecipeClientProfileManager RecipeClientProfileManager { get; }
        IRankManager RankManager { get; }

        ApplicationRoleManager RoleManager { get; }
        Task SaveAsync();
    }
}
