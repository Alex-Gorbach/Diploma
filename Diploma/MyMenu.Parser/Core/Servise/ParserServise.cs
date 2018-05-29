using AngleSharp.Dom;
using System.Collections.Generic;
using WindowsFormsApp1.Core.Recepies;

namespace WindowsFormsApp1.Core.Servise
{
    public class ParserServise:IService
    {

        public List<string> SetColllection(List<string> destionation, IEnumerable<IElement> source)
        {
            foreach (var item in source)
            {
                destionation.Add(item.TextContent);
            }
             return destionation;
        }

        public void InitCollection(ArborioModel arborioModel)
        {
            arborioModel.Number = new List<string>();
            arborioModel.Products = new List<string>();
            arborioModel.Units = new List<string>();
        }
     
    }
}
