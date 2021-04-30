using csY2S2_cs_project.classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace csY2S2_cs_project.Views.mangerScreenViews
{
    /// <summary>
    /// Interaction logic for addNewProduct.xaml
    /// </summary>
    public partial class addNewProduct : Window
    {
        ProductsData db = new ProductsData();
       
        public addNewProduct()
        {
            InitializeComponent();
        }

        private void addBtn_Click(object sender, RoutedEventArgs e)
        {
            using (db)
            {
               
                

                if (valid())
                {
                    var LastID = db.Product.OrderByDescending(i => i.Id)
                         .FirstOrDefault();
                    var result=0;
                    var newID = 0;
                    if (LastID == null)
                    {
                        result = LastID.Id+1;
                    }
                    else
                    {
                        result = LastID.Id;
                        newID = result + 1;
                    }
                    
                   

                    var uId = GenerateID();
                    string Imagename =  Regex.Replace(NameInput.Text, @"\s+", "").ToLower() + uId.ToString() + ".jpg";



                    Products temProduct = new Products { Name = NameInput.Text, Id = newID + 1, Type = typeComboBox.Text, Price = CalculateSellingPrice(costInput.Text, ProfitInput.Text), Description = descriptionInput.Text, Image = "/images/products" + Imagename, UniqId = uId };
                    db.Product.Add(temProduct);
                    db.SaveChanges();
                    string ComplateMessage = string.Format("{0} has been added successfully !, with a uniq id {1}. Do not forget upload image the file name should be {2}", NameInput.Text, uId.ToString(), Imagename);
                    MessageBox.Show(ComplateMessage.ToString());
                }
                else{
                    MessageBox.Show("All fields are required");
                }

            }

        }
        public  Boolean valid()
        {
           

            if (!String.IsNullOrEmpty(NameInput.Text) && !String.IsNullOrEmpty(descriptionInput.Text) && !String.IsNullOrEmpty(ProfitInput.Text) && !String.IsNullOrEmpty(costInput.Text))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public long GenerateID()
        {
            Random random = new Random();

            var RandomuniqId = random.Next(100000, 999999);


            bool exists = db.Product.Any(p => p.UniqId == RandomuniqId);

            if (exists)
            {
                RandomuniqId = random.Next(100000, 999999);
            }
            return RandomuniqId;
        }

        private void ProfitInput_TextChanged(object sender, TextChangedEventArgs e)
        {
            Regex regex = new Regex("[^0-9.-]+");
            if (!regex.IsMatch(ProfitInput.Text) )
            {
                var Sellingprice = CalculateSellingPrice(costInput.Text, ProfitInput.Text);

                SellingPriceText.Text = string.Format($"the selling price will be {Sellingprice:C}"); 


            }
            else
            {

                MessageBox.Show("only numbers can be inserted");
                ProfitInput.Text = ProfitInput.Text.Remove(ProfitInput.Text.Length - 1, 1);
            }
        }

        private void costInput_TextChanged(object sender, TextChangedEventArgs e)
        {
            Regex regex = new Regex("[^0-9.-]+");
            if (!regex.IsMatch(costInput.Text))
            {

                var Sellingprice = CalculateSellingPrice(costInput.Text, ProfitInput.Text);

                SellingPriceText.Text = SellingPriceText.Text = string.Format($"the selling price will be {Sellingprice:C}");
                


            }
            else
            {
                MessageBox.Show("only numbers can be inserted");
                costInput.Text = costInput.Text.Remove(costInput.Text.Length - 1, 1);
               
                
            }

        }

        public  decimal CalculateSellingPrice(string cost,string profit)
        {
            decimal price=0;
            try
            {
                 decimal Cost = decimal.Parse(cost);
                 decimal Profit = decimal.Parse(profit);

                 price = ((Cost * (Profit / 100)) + Cost);


            }
            catch
            {


            }

            return price;


        }


        private void cancelBtn_Click(object sender, RoutedEventArgs e)
        {
            
            this.Close();
        }
    }
}
 