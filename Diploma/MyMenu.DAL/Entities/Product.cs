using System.Collections.Generic;

namespace MyMenu.DAL.Entities
{
    public class Product
    {

        public Product()
        {
            this.Recipies = new HashSet<Recipie>();
        }
        public string Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Recipie> Recipies { get; set; }
    }
}
