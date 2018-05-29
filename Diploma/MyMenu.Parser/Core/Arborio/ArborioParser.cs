using System.Collections.Generic;
using System.Linq;
using AngleSharp.Dom.Html;
using WindowsFormsApp1.Core;
using WindowsFormsApp1.Core.Edaru;
using WindowsFormsApp1.Core.Recepies;
using WindowsFormsApp1.Core.Servise;

namespace WindowsFormsApp1.Recepies
{
    class ArborioParser : IParser<string[]>
    {

        public ArborioModel ParseData(IHtmlDocument document)
        {
            var arborioModel = new ArborioModel();
            var service = new ParserServise();
            service.InitCollection(arborioModel);

            var recipe = document.QuerySelector(".hrecipe");
            var items = recipe.QuerySelector(".fn");

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
                    arborioModel.Number.Add("");
                }
                else
                    foreach (var item in productNumber)
                    {
                        arborioModel.Number.Add(item.TextContent);
                    }
               

                var products = ingredient[i].QuerySelectorAll("span")
                    .Where(item => item.ClassName != null
                    && item.ClassName == "name");
                foreach (var item in products)
                {
                    arborioModel.Products.Add(item.TextContent);
                }

                var unitType = ingredient[i].QuerySelectorAll("span")
                    .Where(item => item.ClassName != null
                    && item.ClassName.Contains("type")
                    && item.ParentElement.ClassName != null
                    && item.ParentElement.ClassName.Contains("ingredient"));
                if (unitType.Count()==0)
                {
                    arborioModel.Units.Add("");
                }
                else
                foreach (var item in unitType)
                {
                        arborioModel.Units.Add(item.TextContent);
                }

            }

            foreach (var item in imageSrc)
            {
                arborioModel.ImageHref = item.GetAttribute("data-lazy-src");
            }

            arborioModel.Name=items.TextContent;

            foreach (var item in descriptions)
            {
                arborioModel.Description += item.TextContent;
            }
             return arborioModel;
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
