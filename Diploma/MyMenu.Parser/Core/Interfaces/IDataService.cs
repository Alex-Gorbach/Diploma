using System;
using System.Threading.Tasks;
using WindowsFormsApp1.Core.Recepies;

namespace WindowsFormsApp1.Core.Servise
{
    public interface IDataService : IDisposable
    {
        Task Create(ArborioModel recipeModel);
    }
}
