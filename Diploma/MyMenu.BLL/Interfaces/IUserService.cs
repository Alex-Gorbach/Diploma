using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using BLL.DTO;
using MyMenu.BLL.Infrastructure;

namespace MyMenu.BLL.Interfaces
{
    public interface IUserService: IDisposable
    {
        Task<OperationDetails> Create(UserDTO userDto);
        Task<ClaimsIdentity> Authenticate(UserDTO userDto);
        Task SetInitialData(UserDTO adminDto, List<string> roles);
        Task<UserDTO> GetUserByEmail(string email);

        List<RecipeDTO> GetAllRecipes(int itemsToSkip,int pageSize);
        RecipeDTO GetRecipeById(int id);
        List<RecipeDTO> GetRecipeByName(string recipeName);
        List<RecipeDTO> GetRecipeByProductsName(string[] productsName);
        bool AddRecipeToUserList(string userId, int recipeId);
        bool ChekIfInUsersList(string userId, int recipeId);
    }
}
