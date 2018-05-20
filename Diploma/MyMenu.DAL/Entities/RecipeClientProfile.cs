using MyMenu.DAL.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Entities
{
    public class RecipeClientProfile
    {
        [Key, Column(Order = 0)]
        public string Id { get; set; }

        [Key, Column(Order = 1)]
        public int RecipeId { get; set; }

        public virtual ClientProfile ClientProfile { get; set; }
        public virtual Recipe Recipe { get; set; }
    }
}
