using System.Collections.Generic;
using System.Linq;
using AngleSharp.Dom.Html;
using WindowsFormsApp1.Core;

namespace WindowsFormsApp1.Habra
{
    class HabraParser : IParser<string[]>
    {
        public string[] Parse(IHtmlDocument document)
        {
            var list = new List<string>();
            var items = document.QuerySelectorAll("a").Where(item => item.ParentElement.ClassName != null  && item.ParentElement.ClassName.Contains("post__title"));
            
            foreach (var item in items)
            {
                list.Add(item.GetAttribute("href"));
            }
            return list.ToArray();
        }
    }
}
