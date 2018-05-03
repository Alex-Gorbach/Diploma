using AngleSharp.Dom.Html;
using WindowsFormsApp1.Core.Recepies;

namespace WindowsFormsApp1.Core
{
    public interface IParser<T>where T:class
    {
        T ParseHref(IHtmlDocument document);
        RecipeModel ParseData(IHtmlDocument document);
    }
}

