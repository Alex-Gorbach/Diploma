using AngleSharp.Dom;
using System.Collections.Generic;
using WindowsFormsApp1.Core.Recepies;

namespace WindowsFormsApp1.Core.Servise
{
    public interface IService
    {
        List<string> SetColllection(List<string> destionation, IEnumerable<IElement> source);
        void InitCollection(ArborioModel arborioModel);
    }
}
