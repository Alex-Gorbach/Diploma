using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.Core.Edaru
{
    public class EdaSettings : IParserSettings
    {
        public EdaSettings(int start, int end)
        {
            StartPoint = start;
            EndPoint = end;
        }

        public string BaseUrl { get; set; } = "https://eda.ru/recepty";
        public string Prefix { get; set; } = "?page={CurrentId}";
        public int StartPoint { get; set; }
        public int EndPoint { get; set; }
    }
}
