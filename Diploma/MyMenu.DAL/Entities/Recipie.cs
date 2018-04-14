using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMenu.DAL.Entities
{
    public class Recipie
    {
        public Recipie()
        {
            this.Products = new HashSet<Product>();
        }
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageHref { get; set; }

        public virtual ICollection<Product> Products { get; set; }

    }
}
