using AutoMapper;
using BLL.DTO;
using DAL.Entities;
using Microsoft.AspNet.Identity;
using MyMenu.BLL.Infrastructure;
using MyMenu.BLL.Interfaces;
using MyMenu.DAL.Entities;
using MyMenu.DAL.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace MyMenu.BLL.Services
{
    public class UserService:IUserService
    {
        IUnitOfWork Database { get; set; }

        public UserService(IUnitOfWork uow)
        {
            Database = uow;
        }
        
        public async Task<OperationDetails> Create(UserDTO userDto)
        {
            ApplicationUser user = await Database.UserManager.FindByEmailAsync(userDto.Email);
            if (user == null)
            {
                user = new ApplicationUser { Email = userDto.Email, UserName = userDto.Email };
                var result = await Database.UserManager.CreateAsync(user, userDto.Password);
                if (result.Errors.Count() > 0)
                    return new OperationDetails(false, result.Errors.FirstOrDefault(), "");
                await Database.UserManager.AddToRoleAsync(user.Id, userDto.Role);

                ClientProfile clientProfile = new ClientProfile { Id = user.Id, Name = userDto.Name };
                Database.ClientManager.Create(clientProfile);
                await Database.SaveAsync();
                return new OperationDetails(true, "Succes registration","");
            }
            else
            {
                return new OperationDetails(false, "User whith this login already exist", "Email");
            }
        }

        public async Task<ClaimsIdentity> Authenticate(UserDTO userDto)
        {
            ClaimsIdentity claim = null;
            ApplicationUser user = await Database.UserManager.FindAsync(userDto.Email, userDto.Password);
            if (user != null)
            {
                claim = await Database.UserManager.CreateIdentityAsync(user, DefaultAuthenticationTypes.ApplicationCookie);
            }
            return claim;
        }

        public async Task SetInitialData(UserDTO adminDto, List<string> roles)
        {
            foreach(string roleName in roles)
            {
                var role = await Database.RoleManager.FindByNameAsync(roleName);
                if (role == null)
                {
                    role = new ApplicationRole { Name = roleName };
                    await Database.RoleManager.CreateAsync(role);
                }
            }
            await Create(adminDto);
        }


        public void Dispose()
        {
            Database.Dispose();
        }



        public List<RecipeDTO> GetAllRecipes(int itemsToSkip,int pageSize)
        {
            var recipesId = new List<int>();
            List<Product> productsList = new List<Product>();
            var result = Database.RecipeManager.GetAllRepices(itemsToSkip, pageSize);
            var recipes = Mapper.Map<List<Recipe>, List<RecipeDTO>>(result);
            foreach (var item in result)
            {
                recipesId.Add(item.RecipeId);
            }

            for (int i = 0; i < recipesId.Count; i++)
            {
                var products = Database.ProductManager.GetProbuctsById(recipesId[i]);
                var productsMap = Mapper.Map<List<Product>, List<ProductDTO>>(products);
                var productCopasity = Database.ProductManager.GetProductsCopasity(recipesId[i]);
                recipes.ElementAt(i).Products = productsMap;
                recipes.ElementAt(i).ProductCopasity = productCopasity;
            }
            return recipes;
        }

        public async Task<UserDTO> GetUserByEmail(string email)
        {
            var user = new UserDTO();
            var result =await Database.UserManager.FindByEmailAsync(email);
            user.Name = result.ClientProfile.Name;
            
            return user;
        }

        public RecipeDTO GetRecipeById(int id)
        {
            List<Product> productsList = new List<Product>();
            var result = Database.RecipeManager.GetRecipeById(id);
            var recipe = Mapper.Map<Recipe, RecipeDTO>(result);
            var products = Database.ProductManager.GetProbuctsById(id);
            var productsMap = Mapper.Map<List<Product>, List<ProductDTO>>(products);
            var productCopasity = Database.ProductManager.GetProductsCopasity(id);
            recipe.Products = productsMap;
            recipe.ProductCopasity = productCopasity;
            return recipe;
        }

        public List<RecipeDTO> GetRecipeByName(string recipeName)
        {
            var recipes = new List<Recipe>();
     
            var result = Database.RecipeManager.GetRecipeByName(recipeName);
            foreach (var item in result)
            {
                recipes.Add(item);
            }
            var recipesInfo =new List<RecipeDTO>();
            for (int i = 0; i < recipes.Count; i++)
            {
                var index = recipes.ElementAt(i).RecipeId;
                var recipe = GetRecipeById(index);
                recipesInfo.Add(recipe);
            }

            return recipesInfo;

        }

        public List<RecipeDTO> GetRecipeByProductsName(string[] productsName)
        {
            var products = new List<Product>();
            var recipesProducts = new List<Product>();
            var productsCount = productsName.Count();
            for (int i = 0; i < productsCount; i++)
            {
                var productInfo = Database.ProductManager.GetProductByName(productsName[i]);
                foreach (var item in productInfo)
                {
                    products.Add(item);
                }
            }

            var recipesId = new List<int>();
            var productId = products.ElementAt(0).ProductId;
            var listProducts = Database.RecipeProductManager.GetRecipeIdByProductId(productId).Select(x=>x.RecipeId);
            for (int i = 1; i < products.Count; i++)
            {

                productId = products.ElementAt(i).ProductId;
                var templist = Database.RecipeProductManager.GetRecipeIdByProductId(productId).Select(x=>x.RecipeId);
                listProducts = listProducts.Intersect(templist);

            }


            var recipes = new List<RecipeDTO>();
            for (int i = 0; i < listProducts.Count(); i++)
            {
                var recipeId = listProducts.ElementAt(i);
                var recipe = GetRecipeById(recipeId);
                recipes.Add(recipe);
            }

            return recipes;
        }

        public bool AddRecipeToUserList(string userId, int recipeId)
        {
            var recipeClient = new RecipeClientProfile()
            {
                Id = userId,
                RecipeId = recipeId
            };
            var recipeUser = Database.RecipeClientProfileManager.FindByRecipeAndUserId( userId,  recipeId);
            if (recipeUser == null)
            {
                Database.RecipeClientProfileManager.Create(recipeClient);
                return true;
            }
           
            return false;
           
        }
    }


}
