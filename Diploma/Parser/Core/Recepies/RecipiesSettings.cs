
namespace Parser.Core.Recepies
{
    class RecipiesSettings : IParserSettings
    {
        public HabraSettings(int start, int end)
        {
            StartPoint = start;
            EndPoint = end;
        }


        public string BaseUrl { get; set; } = "https://www.allrecipes.com/";
        public string Prefix { get; set; } = "page{CurrentId}";
        public int StartPoint { get; set; }
        public int EndPoint { get; set; }
    }
}
