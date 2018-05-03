using MyMenu.DAL.EF;
using MyMenu.DAL.Entities;
using MyMenu.DAL.Interfaces;
using System.Linq;

namespace MyMenu.DAL.Repositories
{
    public class ClientManager : IClientManager
    {
        public ApplicationContext Database { get; set; }
        public ClientManager(ApplicationContext db)
        {
            Database = db;
        }

        public void Create(ClientProfile item)
        {
            Database.ClientProfiles.Add(item);
            Database.SaveChanges();
            
        }

        public void Dispose()
        {
            Database.Dispose();
        }

    }
}
