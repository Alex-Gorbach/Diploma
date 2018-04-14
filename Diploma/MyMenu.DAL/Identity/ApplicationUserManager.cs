using MyMenu.DAL.Entities;
using Microsoft.AspNet.Identity;

namespace MyMenu.DAL.Identity
{
    public class ApplicationUserManager : UserManager<ApplicationUser>
    {
        public ApplicationUserManager(IUserStore<ApplicationUser> store):base(store){}
    }
}
