using csY2S2_cs_project.classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataManagment
{
    class Program
    {
        static void Main(string[] args)
        {

            ProductsData db = new ProductsData();

            using (db)
            {
                //create some products

                Products p1 = new Products { Name = "Milk", Id =1, Type = "diray", Price = 2.5m, Description = "the primary source of nutrition for young mammals, including breastfed human infants before they are able to digest solid food.", Image = "/images/products/milk.jpg", UniqId = GenerateID() };
                

                // add the objs to the database 
                db.Product.Add(p1);
            


                Console.WriteLine("saving...");
                //save data to the database
                db.SaveChanges();
            }
        }
        public static long GenerateID()
        {
            Random random = new Random();
            return random.Next(100000, 999999);

        }
    }
}
