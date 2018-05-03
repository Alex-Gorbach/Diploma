using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyMenu.DAL.Entities
{
    public class ClientProfile
    {
        public ClientProfile()
        {
            this.Recipes = new HashSet<Recipe>();
        }

        [Key]
        [ForeignKey("ApplicationUser")]
        public string Id { get; set; }
        public string Name { get; set; }
        
        public virtual ApplicationUser ApplicationUser { get; set; }
        public virtual ICollection<Recipe> Recipes { get; set; }
    }
}
