using AngleSharp.Dom.Html;

namespace WindowsFormsApp1.Core
{
    public interface IParser<T>where T:class
    {
        T Parse(IHtmlDocument document);
    }
}

