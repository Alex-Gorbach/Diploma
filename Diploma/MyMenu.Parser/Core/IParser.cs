using AngleSharp.Dom.Html;

namespace MyMenu.Parser.Core
{
    interface IParser<T> where T : class
    {
        T Parse(IHtmlDocument document);
    }
}
