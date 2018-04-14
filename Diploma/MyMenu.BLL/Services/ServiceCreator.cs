using MyMenu.BLL.Interfaces;
using MyMenu.DAL.Repositories;

namespace MyMenu.BLL.Services
{
    public class ServiceCreator:IServiceCreator
    {
        public IUserService CreateUserService(string connection)
        {
            return new UserService(new IdentityUnitOfWork(connection));
        }
    }
}
