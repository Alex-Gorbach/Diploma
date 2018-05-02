using AutoMapper;
using BLL.DTO;
using MyMenu.DAL.Entities;

namespace BLL.Services
{
    public class AutoMapperConfig
    {
        public static void Initialize()
        {
            Mapper.Initialize(cfg => cfg.CreateMap<Recipe, RecipeDTO>());
        }
    }
}
