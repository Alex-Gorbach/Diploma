using System.Collections.Generic;

namespace BLL.DTO
{
    public class RecipeDTO
    {
        public int RecipeId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageHref { get; set; }
        public List<ProductDTO> Products {get; set;}
        public List<string> ProductCopasity { get; set; }
        public double Rating { get; set; }
    }
}
