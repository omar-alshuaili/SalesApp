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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace csY2S2_cs_project.Views.mangerScreenViews
{
    /// <summary>
    /// Interaction logic for ProductsUserControl.xaml
    /// </summary>
    public partial class ProductsUserControl : UserControl
    {
        ProductsData db = new ProductsData();

        public ProductsUserControl()
        {
            InitializeComponent();
        }

        private void nameInput_TextChanged(object sender, TextChangedEventArgs e)
        {
            imageInput.Text = "/images/products/";

            imageInput.Text += Regex.Replace(nameInput.Text, @"\s+", "").ToLower() + UniqIdInput.Text + ".jpg";



        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            var q = from p in db.Product
                    select p;


            ProductsListBox.ItemsSource = q.ToList();
        }

        private void ProductsListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Products selectedItem = ProductsListBox.SelectedItem as Products;
            if (selectedItem != null)
            {
                nameInput.Text = selectedItem.Name;
                typeInput.Text = selectedItem.Type;
                priceInput.Text = selectedItem.Price.ToString(); ;
                imageInput.Text = selectedItem.Image;
                UniqIdInput.Text = selectedItem.UniqId.ToString();
            }
        }

        private void addNewProductbtn_Click(object sender, RoutedEventArgs e)
        {

            addNewProduct addNew = new addNewProduct();
            addNew.Show();




        }

        private void searchInput_TextChanged(object sender, TextChangedEventArgs e)
        {
            var searchQuery = from x in db.Product
                              where x.Name.Contains(searchINput.Text) || x.UniqId.ToString().Contains(searchINput.Text)
                              select x;

            ProductsListBox.ItemsSource = searchQuery.ToList();

        }

        private void deleteProduct_Click(object sender, RoutedEventArgs e)
        {
            Products selesctedProduct = ProductsListBox.SelectedItem as Products;
            if (selesctedProducts != null)
            {
                using (db)
                {
                    var x = (from p in db.Product
                             where p.UniqId == selesctedProduct.UniqId
                             select p).FirstOrDefault();
                    db.Product.Remove(x);
                    db.SaveChanges();
                }
            }


        }




        private void saveProduct_Click(object sender, RoutedEventArgs e)
        {

            Products selesctedProduct = ProductsListBox.SelectedItem as Products;
            if (selesctedProduct != null)
            {
                using (db)
                {
                    var x = (from p in db.Product
                             where p.UniqId == selesctedProduct.UniqId
                             select p).FirstOrDefault();


                    x.Name = nameInput.Text;
                    x.Description = descriptionInput.Text;
                    x.Price = decimal.Parse(priceInput.Text);

                    db.SaveChanges();
                }
            }
        }
    }
}
