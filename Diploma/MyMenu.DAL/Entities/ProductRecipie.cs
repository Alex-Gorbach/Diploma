using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMenu.DAL.Entities
{
    public class ProductsRecipies
    {
        public string Id { get; set; }
        public string ProductId { get; set; }
        public string PecipiesId { get; set; }
        public double Number { get; set; }
        public string UnitId { get; set; }
    }

}
