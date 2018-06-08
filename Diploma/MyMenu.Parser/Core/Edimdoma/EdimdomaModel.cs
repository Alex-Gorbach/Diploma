using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.Core.Edimdoma
{
    public class EdimdomaModel
    {
        public string Name { get; set; }
        public string ImageHref { get; set; }
        public string Description { get; set; }
        public List<string> Products { get; set; }
        public List<string> Number { get; set; }
        public List<string> Units { get; set; }
    }
}
