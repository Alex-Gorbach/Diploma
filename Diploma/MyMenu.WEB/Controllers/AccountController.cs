using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;
using Microsoft.Owin.Security;
using Microsoft.AspNet.Identity.Owin;
using System.Threading.Tasks;
using MyMenu.WEB.Models;
using BLL.DTO;
using System.Security.Claims;
using MyMenu.BLL.Interfaces;
using MyMenu.BLL.Infrastructure;
using Microsoft.AspNet.Identity;
using System;

namespace MyMenu.WEB.Controllers
{
    public class AccountController : Controller
    {
        private IUserService UserService
        {
            get
            {
                return HttpContext.GetOwinContext().GetUserManager<IUserService>();
            }
        }

        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }


        public ActionResult Login()
        {
            return View();
        }

        public async Task<ActionResult> UsersProfile()
        {
            var userEmail = User.Identity.Name;
            var user = await UserService.GetUserByEmail(userEmail);
            return View(user);
        }

        public ActionResult GetUsersRecipes()
        {
            var userId = User.Identity.GetUserId();
            var usersRecipes = UserService.GetUsersRecipes(userId);
            return PartialView("_UsersRecipesTable", usersRecipes);
        }

        public ActionResult GetTopRecipes()
        {
            var result = UserService.GetTopFiveRankedRacipes();
            foreach (var item in result)
            {
               item.Rank= Math.Round(item.Rank,1);
            }
            return PartialView("_TopFiveRecipes", result);
        }

        public ActionResult DeleteRecipeFromUserList(int recipeId)
        {
            var userId = User.Identity.GetUserId();
            UserService.DeleteRecipeFromUserList(recipeId, userId);

            return RedirectToAction("UsersProfile");
        }



        public ActionResult Update()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginModel model)
        {
            await SetInitialDataAsync();
            if (ModelState.IsValid)
            {
                UserDTO userDto = new UserDTO { Email = model.Email, Password = model.Password };
                ClaimsIdentity claim = await UserService.Authenticate(userDto);
                if (claim == null)
                {
                    ModelState.AddModelError("", "Wrong Login or password");
                }
                else
                {
                    AuthenticationManager.SignOut();
                    AuthenticationManager.SignIn(new AuthenticationProperties
                    {
                        IsPersistent = true
                    }, claim);
                    return RedirectToAction("Index", "Home");
                }
            }
            return View(model);
        }

        public ActionResult Logout()
        {
            AuthenticationManager.SignOut();
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Register(RegisterModel model)
        {
            await SetInitialDataAsync();
            if (ModelState.IsValid)
            {
                UserDTO userDto = new UserDTO
                {
                    Email = model.Email,
                    Password = model.Password,
                    Name = model.Name,
                    Role = "user"
                };
                OperationDetails operationDetails = await UserService.Create(userDto);
                if (operationDetails.Succedeed)
                    return View("SuccessRegister");
                else
                    ModelState.AddModelError(operationDetails.Property, operationDetails.Message);
            }
            return View(model);
        }
        private async Task SetInitialDataAsync()
        {
            await UserService.SetInitialData(new UserDTO
            {
                Email = "admin@mail.ru",
                UserName = "admin@mail.ru",
                Password = "ad46D_ewr3",
                Name = "Admin Admin Admin",
                Role = "admin",
            }, new List<string> { "user", "admin" });
        }
    }
}