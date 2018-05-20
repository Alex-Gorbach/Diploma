using DAL.Entities;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyMenu.DAL.Entities
{
    public class Recipe
    {
        //public Recipe() {
        //    this.RecipeClientProfile = new HashSet<RecipeClientProfile>();
        //}

        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RecipeId { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageHref { get; set; }

        public virtual ICollection<RecipeClientProfile> RecipeClientProfile { get; set; }

    }
}
