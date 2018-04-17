using System.Collections.Generic;

namespace MyMenu.DAL.Entities
{
    public class RecipeProduct
    {
        public string Id { get; set; }
        public double Number { get; set; }

        public virtual ICollection<Product> Products { get; set; }
        public virtual ICollection<Recipe> Recipes { get; set; }
    }

}
