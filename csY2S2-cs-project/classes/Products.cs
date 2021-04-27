using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;

namespace csY2S2_cs_project.classes
{
    public class Products
    {
        public string Name { get; set; }
        public long Id { get; set; }
        public string Type { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }

    }

    
}
