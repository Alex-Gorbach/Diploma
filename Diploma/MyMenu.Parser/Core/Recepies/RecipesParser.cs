using System.Collections.Generic;
using System.Linq;
using AngleSharp.Dom.Html;


namespace MyMenu.Parser.Core.Recepies
{
    class RecipesParser : IParser<string[]>
    {
        public string[] Parse(IHtmlDocument document)
        {
            var list = new List<string>();
            var items = document.QuerySelectorAll("h3").Where(item => item.ClassName != null && item.ClassName.Contains("grid-col__h3 grid-col__h3--recipe-grid"));

            foreach (var item in items)
            {
                list.Add(item.TextContent);
            }
            return list.ToArray();
        }
    }
}
