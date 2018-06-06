using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyMenu.DAL.Entities
{
    public class RecipeProduct
    {

        [Key, Column(Order = 0)]
        public int ProductId { get; set; }

        [Key, Column(Order = 1)]
        public int RecipeId { get; set; }

       

        public virtual Product Product { get; set; }
        public virtual Recipe Recipe { get; set; }

        public string Number { get; set; }

    }

}
