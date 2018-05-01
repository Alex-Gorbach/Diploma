using BLL.DTO;
using MyMenu.BLL.Infrastructure;
using MyMenu.BLL.Interfaces;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using System.Security.Claims;
using MyMenu.DAL.Interfaces;
using MyMenu.DAL.Entities;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;

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



        public List<RecipeDTO> GetAllRecipes()
        {

            var result = Database.RecipeManager.GetAllRepices();
            Mapper.Initialize(cfg => cfg.CreateMap<Recipe,RecipeDTO>());
            var recipes = Mapper.Map<List<Recipe>,List<RecipeDTO>>(result);
           
            return recipes;
        }

        public async Task<UserDTO> GetUserByEmail(string email)
        {
            var user = new UserDTO();
            var result =await Database.UserManager.FindByEmailAsync(email);
            user.Name = result.ClientProfile.Name;
            
            return user;
        }
    }


}
