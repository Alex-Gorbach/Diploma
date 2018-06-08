using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.Core.Edimdoma
{
    public class EdimdomaSettings : IParserSettings
    {
        public EdimdomaSettings( int start, int end )
        {
            StartPoint = start;
            EndPoint = end;
        }

        public string BaseUrl { get; set; } = "http://povar.ru/";
        public string Prefix { get; set; } = "mostnew/all/{CurrentId}";
        public int StartPoint { get; set; }
        public int EndPoint { get; set; }
    }
}
