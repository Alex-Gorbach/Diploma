using WindowsFormsApp1.Core;

namespace WindowsFormsApp1.Recepies
{
    class ArborioSettings : IParserSettings
    {
        public ArborioSettings(int start, int end)
        {
            StartPoint = start;
            EndPoint = end;
        }

        public string BaseUrl { get; set; } = "https://eda.ru/";
        public string Prefix { get; set; } = "recepty?page={CurrentId}";
        public int StartPoint { get; set; }
        public int EndPoint { get; set; }
    }
}
    