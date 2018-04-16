using System.Collections.Generic;
using System.Linq;
using AngleSharp.Dom.Html;
using WindowsFormsApp1.Core;
using WindowsFormsApp1.Core.Recepies;
using WindowsFormsApp1.Core.Servise;

namespace WindowsFormsApp1.Recepies
{
    class RecipeParser : IParser<string[]>
    {
        public RecipeModel ParseData(IHtmlDocument document)
        {
            var recipeModel = new RecipeModel();
            var service = new Servise();
            service.InitCollection(recipeModel);
            
            var items = document.QuerySelectorAll("h1")
                .Where(item => item.ClassName != null
                && item.ClassName.Contains("post__title"));

            var descriptions=document.QuerySelectorAll("span")
                .Where(item => item.ClassName != null
                && item.ClassName.Contains("instruction"));

            var imageSrc =document.QuerySelectorAll("img")
                .Where(item => item.ParentElement.ClassName != null 
                && item.ParentElement.ClassName.Contains("preview"));

            var productNumber = document.QuerySelectorAll("span")
                .Where(item => item.ClassName != null
                && (  item.ClassName.Contains("value") || item.ClassName.Contains("amount")));
            service.SetColllection(recipeModel.Number, productNumber);

            var products = document.QuerySelectorAll("span")
                .Where(item => item.ClassName != null
                && item.ClassName.Contains("name")
                && item.ParentElement.ClassName.Contains("ingredient"));
            service.SetColllection(recipeModel.Products, products);

            var unitType = document.QuerySelectorAll("span")
                  .Where(item => item.ClassName != null
                && item.ClassName.Contains("type") 
               );
            service.SetColllection(recipeModel.Units, unitType);


            foreach (var item in imageSrc)
            {
                recipeModel.ImageHref = item.GetAttribute("data-lazy-src");
            }

            foreach (var item in items)
            {
                recipeModel.Name=item.TextContent;
               
            }
            foreach (var item in descriptions)
            {
                recipeModel.Description += item.TextContent;
            }
            return recipeModel;
        }

        public string[] ParseHref(IHtmlDocument document)
        {
            var list = new List<string>();
            var items = document.QuerySelectorAll("a")
                .Where(item => item.ParentElement.ClassName != null  
                && item.ParentElement.ClassName.Contains("post__title"));
            
            foreach (var item in items)
            {
                list.Add(item.GetAttribute("href"));
            }
            return list.ToArray();
        }
    }
}
