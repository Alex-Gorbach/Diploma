using System;
using System.Collections.Generic;
using System.Linq;
using AngleSharp.Dom.Html;
using Newtonsoft.Json.Linq;
using WindowsFormsApp1.Core;
using WindowsFormsApp1.Core.Arborio;

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

            var recipe = document.QuerySelector(".main-content");

            var descriptions = recipe.QuerySelectorAll("ul")
                .Where(item => item.ClassName != null
                && item.ClassName.Contains("recipe__steps"));

            foreach (var item in descriptions)
            {
                arborioModel.Description += item.TextContent;
            }

            //var imageSrc = recipe.QuerySelectorAll("img")
            //    .Where(item => item.ParentElement.ClassName != null
            //    && item.ParentElement.ClassName.Contains("gall__item js-gall-item js-gall-item__image _active")
            //   );
            //var dds = recipe.QuerySelector("html body.layout.narrow-view.g-desktop div.popup__fade.js-fader");
            //arborioModel.ImageHref = imageSrc.ElementAt(2).GetAttribute("src");

            //foreach (var item in imageSrc)
            //{
            //    arborioModel.ImageHref = item.GetAttribute("src");
            //}

            var consist = document.QuerySelector("html body.layout.narrow-view.g-desktop div.wrapper-sel section.main-content.layout__container.js-main-content section.recipe.js-portions-count-parent.js-recipe div.g-relative.js-responsive-banner-relative div.ingredients-list.layout__content-col");
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
            arborioModel.Name = recipe.QuerySelector(".recipe__name").TextContent;
            arborioModel.Units = productsAmount;
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
                var parsHref = item.GetAttribute("data-src").Replace("c285x285", "c620x500"); ;

                imageHrefs.Add(parsHref);
            }
            return imageHrefs.ToArray();
        }

        public string[] ParseHref(IHtmlDocument document)
        {
            var hrefModel = new HrefsModel();
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
