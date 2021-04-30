using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;
using System.Data.Entity;

namespace csY2S2_cs_project.classes
{
    public class Products
    {
        public string Name { get; set; }
        public int Id { get; set; }
        public long UniqId { get; set; }
        public string Type { get; set; }
        public decimal Price { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }

     

    }

    public class ProductsData : DbContext
    {
        public ProductsData() : base("ProductsData") { }
        public DbSet<Products> Product { get; set; }
    }


}
