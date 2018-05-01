using MyMenu.BLL.Interfaces;
using Microsoft.AspNet.Identity.Owin;
using System.Web;
using System.Web.Mvc;
using BLL.DTO;
using System.Collections.Generic;

namespace MyMenu.WEB.Controllers
{
    public class HomeController : Controller
    {
        private IUserService UserService
        {
            get
            {
                return HttpContext.GetOwinContext().GetUserManager<IUserService>();
            }
        }
 
        public ActionResult Index()
        {
            var result = UserService.GetAllRecipes();

            return View(result);
        }

        public ActionResult SearchRecipe()
        {
            return View();
        }


        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Recipe()
        {
            return View();
        }
    }
}