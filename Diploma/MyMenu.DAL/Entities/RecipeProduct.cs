using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyMenu.DAL.Entities
{
    public class RecipeProduct
    {
        
        [Key,Column(Order=1)]
        public int ProductId { get; set; }

       
        [Key, Column(Order = 2)]
        public int RecipeId { get; set; }

        public string Number { get; set; }

    }

}
