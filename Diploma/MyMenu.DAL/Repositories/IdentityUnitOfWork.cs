using MyMenu.DAL.EF;
using MyMenu.DAL.Entities;
using MyMenu.DAL.Interfaces;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Threading.Tasks;
using MyMenu.DAL.Identity;
using DAL.Repositories;
using DAL.Interfaces;

namespace MyMenu.DAL.Repositories
{
    public class IdentityUnitOfWork : IUnitOfWork
    {
        private ApplicationContext db;

        private ApplicationUserManager userManager;
        private ApplicationRoleManager roleManager;
        private IClientManager clientManager;
        private IRecipeManager recipeManager;
        private IProductManager productManager;
        private IRecipeProductManager recipeProductManager;

        public IdentityUnitOfWork(string connectionString)
        {
            db = new ApplicationContext(connectionString);
            userManager = new ApplicationUserManager(new UserStore<ApplicationUser>(db));
            roleManager = new ApplicationRoleManager(new RoleStore<ApplicationRole>(db));
            clientManager = new ClientManager(db);
            recipeManager = new RecipeManager(db);
            productManager=new ProductManager(db);
            recipeProductManager=new RecipeProductManager(db);
        }

        public ApplicationUserManager UserManager
        {
            get { return userManager; }
        }

        public IClientManager ClientManager
        {
            get { return clientManager; }
        }

        public ApplicationRoleManager RoleManager
        {
            get { return roleManager; }
        }

        public IProductManager ProductManager
        {
            get { return productManager; }
        }

        public IRecipeManager RecipeManager
        {
            get { return recipeManager; }
        }
        public IRecipeProductManager RecipeProductManager
        {
            get { return recipeProductManager; }
        }

        public async Task SaveAsync()
        {
            await db.SaveChangesAsync();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    userManager.Dispose();
                    roleManager.Dispose();
                    clientManager.Dispose();
                    recipeManager.Dispose();
                    productManager.Dispose();
                    recipeProductManager.Dispose();
                }
                this.disposed = true;
            }
        }
    }
}