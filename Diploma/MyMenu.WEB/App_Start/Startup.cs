using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;
using MyMenu.BLL.Services;
using Microsoft.AspNet.Identity;
using MyMenu.BLL.Interfaces;


[assembly: OwinStartup(typeof(MyMenu.WEB.App_Start.Startup))]

namespace MyMenu.WEB.App_Start
{
    public class Startup
    {
        IServiceCreator serviceCreator = new ServiceCreator();
        public void Configuration(IAppBuilder app)
        {
            app.CreatePerOwinContext<IUserService>(CreateUserService);
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Account/Login"),
            });
        }

        private IUserService CreateUserService()
        {
            return serviceCreator.CreateUserService("MyMenuContext");
        }
    }
}