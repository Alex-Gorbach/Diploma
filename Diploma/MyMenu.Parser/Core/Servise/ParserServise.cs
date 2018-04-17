using AngleSharp.Dom;
using System.Collections.Generic;
using WindowsFormsApp1.Core.Recepies;

namespace WindowsFormsApp1.Core.Servise
{
    public class ParserServise:IService
    {

        public List<string> SetColllection(List<string> destionation, IEnumerable<IElement> source)
        {

            foreach (var item in source)
            {
                destionation.Add(item.TextContent);
            }
             return destionation;
        }

        public void InitCollection(RecipeModel recipeModel )
        {
            recipeModel.Number = new List<string>();
            recipeModel.Products = new List<string>();
            recipeModel.Units = new List<string>();
        }
     
    }
}
