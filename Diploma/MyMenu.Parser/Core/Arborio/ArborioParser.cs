using System;
using System.Collections.Generic;
using System.Linq;
using AngleSharp.Dom.Html;
using Newtonsoft.Json.Linq;
using WindowsFormsApp1.Core;
using WindowsFormsApp1.Core.Recepies;
using WindowsFormsApp1.Core.Servise;

namespace WindowsFormsApp1.Recepies
{
    class ArborioParser : IParser<string[]>
    {

        public ArborioModel ParseData(IHtmlDocument document)
        {
            var recipe = document.QuerySelector(".main-content");
             var arborioModel = new ArborioModel();
            if (recipe != null)
            {
               
                var service = new ParserServise();
                service.InitCollection(arborioModel);
                var descriptions = recipe.QuerySelector(".recipe__steps");
                if (descriptions != null)
                {
                    var descriptinfo = descriptions.QuerySelectorAll("li").Where(
                        item => item.ClassName.Contains("instruction"));
                    foreach (var item in descriptinfo)
                    {
                        arborioModel.Description += item.QuerySelector(".instruction__description").TextContent;
                    }
                }
                var consist = document.QuerySelector(".ingredients-list__content");
                var ingredient = consist.QuerySelectorAll("p")
                    .Where(item => item.ParentElement.ClassName != null
                    && item.ParentElement.ClassName.Contains("ingredients-list__content")
                    && item.ClassName != null
                    && item.ClassName.Contains("ingredients-list__content-item content-item js-cart-ingredients"));
                List<JObject> ingredientsJson = new List<JObject>();
                foreach (var item in ingredient)
                {
                    var ds = item.GetAttribute("data-ingredient-object");
                    var objects = JObject.Parse(ds);
                    ingredientsJson.Add(objects);
                }
                var productsNames = new List<string>();
                var productsAmount = new List<string>();
                foreach (JObject item in ingredientsJson)
                {
                    productsNames.Add((string)item["name"]);
                    productsAmount.Add((string)item["amount"]);
                }
                arborioModel.Number = productsAmount;
                arborioModel.Products = productsNames;
                arborioModel.Name = recipe.QuerySelector(".recipe__name").TextContent+"\n";
                arborioModel.Units = productsAmount;
            }
            return arborioModel;
        }

        public string[] ParseImageHrefs(IHtmlDocument document)
        {
            var pageHrefs = new List<string>();

            var image = document.QuerySelectorAll("div")
                .Where(item => item.ParentElement.ClassName != null
              && item.ParentElement.ClassName.Contains("horizontal-tile__item-link js-click-link ") && item.ClassName != null
              && item.ClassName.Contains("lazy-load-container"));

            var imageHrefs = new List<string>();
            foreach (var item in image)
            {
                var parsHref = item.GetAttribute("data-src").Replace("c285x285", "c620x500");

                imageHrefs.Add(parsHref);
            }
            return imageHrefs.ToArray();
        }

        public string[] ParseHref(IHtmlDocument document)
        {
         
            var pageHrefs = new List<string>();

            var items = document.QuerySelectorAll("a")
                .Where(item => item.ParentElement.ClassName != null
                && item.ParentElement.ClassName.Contains("horizontal-tile__item-title item-title")
                && item.FirstElementChild.ClassName != "item-title__special item-title__special_logo"
                && item.FirstElementChild.ClassName != "item-title__special item-title__special_crown");
            foreach (var item in items)
            {
                pageHrefs.Add(item.GetAttribute("href"));
            }

            return pageHrefs.ToArray();
        }
    }
}
