using System.Collections.Generic;

namespace WindowsFormsApp1.Core.Recepies
{
    public class ArborioModel
    {
        public string Name { get; set; }
        public string ImageHref { get; set; }
        public string Description { get; set; }
        public List<string> Products { get; set; }
        public List<string> Number { get; set; }
        public List<string> Units { get; set; }
    }
}
