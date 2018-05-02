using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using BLL.DTO;
using Microsoft.AspNet.Identity;
using MyMenu.BLL.Infrastructure;
using MyMenu.DAL.Entities;

namespace MyMenu.BLL.Interfaces
{
    public interface IUserService: IDisposable
    {
        Task<OperationDetails> Create(UserDTO userDto);
        Task<ClaimsIdentity> Authenticate(UserDTO userDto);
        Task SetInitialData(UserDTO adminDto, List<string> roles);
        Task<UserDTO> GetUserByEmail(string email);

        List<RecipeDTO> GetAllRecipes(int itemsToSkip,int pageSize);
        
    }
}
