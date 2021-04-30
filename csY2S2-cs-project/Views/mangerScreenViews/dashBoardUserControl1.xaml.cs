using csY2S2_cs_project.classes;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
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
    /// Interaction logic for dashBoardUserControl1.xaml
    /// </summary>
    public partial class dashBoardUserControl1 : UserControl
    {
        public List<List<Products>> ProductList = new List<List<Products>>();
        public List<Products> json = new List<Products>(); 
        public dashBoardUserControl1()
        {
            InitializeComponent();






        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {


            using (StreamReader sr = new StreamReader("C:/Users/s00190262/Desktop/csY2S2-cs-project/csY2S2-cs-project/json/test.json"))
            {
                





                string result = sr.ReadToEnd();
                try
                {
                    json = JsonConvert.DeserializeObject<List<Products>>(result);
                    foreach (var item in json)
                    {
                        ProductList.Add(json);

                    }
                    ProductListBox.ItemsSource = json.ToList();

                }
                catch (Exception x)
                {

                    MessageBox.Show(x.ToString());
                }

                sr.Close();
            }
           


        }

       

        private void ProductListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Products product =  ProductListBox.SelectedItem as Products;
            if (product != null ) {
                productNameInfoPanel.Text = product.Name.ToString();
                productIdInfoPanel.Text = product.Id.ToString();
                productPriceInfoPanel.Text = $"${product.Price:#,0.00}";

                productdescriptionInfoPanel.Text = product.Description.ToString();
            }
           
        }

        private void searchInput_TextChanged(object sender, TextChangedEventArgs e)
        {
            var searchQuery = from x in json
                              where x.Name.Contains(searchInput.Text)
                              select x;
            
            ProductListBox.ItemsSource = searchQuery.ToList();
        }

        private void fruitsbtn_Click(object sender, RoutedEventArgs e)
        {
            var filterQuery = from x in json
                              where x.Type == "fruit"
                              select x;

            ProductListBox.ItemsSource = filterQuery.ToList();
        }

        private void bakerybtn_Click(object sender, RoutedEventArgs e)
        {
            var filterQuery = from x in json
                              where x.Type == "bakery"
                              select x;

            ProductListBox.ItemsSource = filterQuery.ToList();
        }

        private void meatbtn_Click(object sender, RoutedEventArgs e)
        {
            var filterQuery = from x in json
                              where x.Type == "meat"
                              select x;

            ProductListBox.ItemsSource = filterQuery.ToList();
        }

        private void vegbtn_Click(object sender, RoutedEventArgs e)
        {
            var filterQuery = from x in json
                              where x.Type == "vegetable"
                              select x;

            ProductListBox.ItemsSource = filterQuery.ToList();

        }

        private void dairybtn_Click(object sender, RoutedEventArgs e)
        {
            var filterQuery = from x in json
                              where x.Type == "dairy"
                              select x;

            ProductListBox.ItemsSource = filterQuery.ToList();

        }

        private void oilbtn_Click(object sender, RoutedEventArgs e)
        {
            var filterQuery = from x in json
                              where x.Type == "oil"
                              select x;

            ProductListBox.ItemsSource = filterQuery.ToList();

        }


        private void Rest_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            var filterQuery = from x in json
                              select x;


            ProductListBox.ItemsSource = filterQuery.ToList();
            searchInput.Text = "";
        }
    }
}
