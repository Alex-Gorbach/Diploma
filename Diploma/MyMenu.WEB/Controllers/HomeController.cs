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
        
        const int pageSize = 3;

        public ActionResult Index(int? id)
        {

          
            int page = id ?? 0;
            if (Request.IsAjaxRequest())
            {
                return PartialView("_Items", GetItemsPage(page));
            }
            return View(GetItemsPage(page));

        }

        private List<RecipeDTO> GetItemsPage(int page = 1)
        {
            var itemsToSkip = page * pageSize;
            return UserService.GetAllRecipes(itemsToSkip, pageSize);
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

        [HttpPost]
        public ActionResult Recipe(RecipeDTO item)
        {
            return View(item);
        }
    }
}