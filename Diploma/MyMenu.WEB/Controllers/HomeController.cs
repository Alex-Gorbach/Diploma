using MyMenu.BLL.Interfaces;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System.Web;
using System.Web.Mvc;
using BLL.DTO;
using System.Collections.Generic;
using System;

namespace MyMenu.WEB.Controllers
{
    public class HomeController : Controller
    {
        const int pageSize = 3;

        private IUserService UserService
        {
            get
            {
                return HttpContext.GetOwinContext().GetUserManager<IUserService>();
            }
        }

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


        [HttpPost]
        public ActionResult SerchByArray(string[] searchStr)
        {
            var result = UserService.GetRecipeByProductsName(searchStr);
            return PartialView("_Items",result);
        }

        public ActionResult SearchRecipeByName(string search)
        {
            var result = UserService.GetRecipeByName(search);
           return View(result);
        }


       [HttpPost]
        public bool AddToRecUserRecipeList(int recipeId)
        {
            var userId = User.Identity.GetUserId();
            var result=UserService.AddRecipeToUserList(userId,recipeId);
            return result;
        }

        
        [HttpPost]
        public ActionResult ChekifInList(string[] recipeId)
        {
            var userId = User.Identity.GetUserId();
            var recipeIdVal = Int32.Parse(recipeId[0]);
            var result = UserService.ChekIfInUsersList(userId, recipeIdVal);
            return Json(result);
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

        public ActionResult Recipe(int id)
        {
            var recipe = UserService.GetRecipeById(id);
            return View(recipe);
        }
    }
}