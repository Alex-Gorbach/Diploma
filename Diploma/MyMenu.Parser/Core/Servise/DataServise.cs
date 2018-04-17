using MyMenu.DAL.Interfaces;
using System.Threading.Tasks;
using WindowsFormsApp1.Core.Recepies;

namespace WindowsFormsApp1.Core.Servise
{
    public class DataServise
    {
        IUnitOfWork Database { get; set; }

        public DataServise(IUnitOfWork uow)
        {
            Database = uow;
        }

        public async Task Create(RecipeModel userDto)
        {
            
        }
    }
}
