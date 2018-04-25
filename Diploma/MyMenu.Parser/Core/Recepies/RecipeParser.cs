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
            var service = new ParserServise();
            service.InitCollection(recipeModel);

            var recipe = document.QuerySelector(".hrecipe");

            var items = recipe.QuerySelector(".fn");
                //.Where(item => item.ClassName != null
                //&& item.ClassName.Contains("post__title"));

            var descriptions= recipe.QuerySelectorAll("span")
                .Where(item => item.ClassName != null
                && item.ClassName.Contains("instruction"));

            var imageSrc = recipe.QuerySelectorAll("img")
                .Where(item => item.ParentElement.ClassName != null
                && item.ParentElement.ClassName.Contains("preview"));

            var consist = recipe.QuerySelector(".consist");
            var ingredient = consist.GetElementsByClassName("ingredient");

            for (int i = 0; i < ingredient.Length; i++)
            {
                var productNumber = ingredient[i].QuerySelectorAll("span")
                .Where(item => item.ClassName != null
                && (item.ClassName.Contains("value") || item.ClassName.Contains("amount"))
                && item.ParentElement.ClassName != null
                && item.ParentElement.ClassName.Contains("ingredient"));
                if (productNumber.Count() == 0)
                {
                    recipeModel.Number.Add("");
                }
                else
                    foreach (var item in productNumber)
                    {
                        recipeModel.Number.Add(item.TextContent);
                    }
               

                var products = ingredient[i].QuerySelectorAll("span")
                    .Where(item => item.ClassName != null
                    && item.ClassName == "name"
                    // && item.ParentElement.ClassName!=null
                    //&& item.ParentElement.ClassName.Contains("ingredient")
                    );
                foreach (var item in products)
                {
                    recipeModel.Products.Add(item.TextContent);
                }

                var unitType = ingredient[i].QuerySelectorAll("span")
                    .Where(item => item.ClassName != null
                    && item.ClassName.Contains("type")
                    && item.ParentElement.ClassName != null
                    && item.ParentElement.ClassName.Contains("ingredient"));
                if (unitType.Count()==0)
                {
                    recipeModel.Units.Add("");
                }
                else
                foreach (var item in unitType)
                {
                    recipeModel.Units.Add(item.TextContent);
                }

            }

            //service.SetColllection(recipeModel.Number, values);
            //service.SetColllection(recipeModel.Products, products);
            //service.SetColllection(recipeModel.Units, unitType);
            foreach (var item in imageSrc)
            {
                recipeModel.ImageHref = item.GetAttribute("data-lazy-src");
            }

            //foreach (var item in items)
            //{
                recipeModel.Name=items.TextContent;
               
           // }
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
