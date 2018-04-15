using System.Collections.Generic;

namespace MyMenu.DAL.Entities
{
    public class RecipieProduct
    {
        public string Id { get; set; }
        public double Number { get; set; }

        public virtual ICollection<Product> Products { get; set; }
        public virtual ICollection<Recipie> Recipies { get; set; }
    }

}
