﻿using MyMenu.BLL.Interfaces;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System.Web;
using System.Web.Mvc;
using BLL.DTO;
using System.Collections.Generic;
using System;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

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
            return PartialView("_Items", result);
        }

        public JsonResult GetSuggestProducts(string val)
        {
            var result = UserService.GetProductsName(val);
            string json = JsonConvert.SerializeObject(result);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public ActionResult SearchRecipeByName(string search)
        {
            var result = UserService.GetRecipeByName(search);
            return View(result);
        }


        public ActionResult SetRankByUser( int recipeId,double recipeRank)
        {
            var userId = User.Identity.GetUserId();
            var check = UserService.CheckIfCommitRank(userId, recipeId);
            if (check) { 
                var result = UserService.SetRecipeRank(recipeId, userId, recipeRank);
                var recipe = new RecipeDTO() { Rank = result };
                return PartialView("Rating", recipe);
            }
            return PartialView("Rating", null);
        }

        public ActionResult GetRanks(RecipeDTO recipe)
        {
            return PartialView("Rating", recipe);
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
            ViewBag.Message = "Страница описания приложения.";
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Страница контактов.";
            return View();
        }

        public ActionResult Recipe(int id)
        {
            var recipe = UserService.GetRecipeById(id);
            return View(recipe);
        }

    }
}