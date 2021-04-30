using csY2S2_cs_project.classes;
using csY2S2_cs_project.Views.mangerScreenViews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using csY2S2_cs_project.Views.startWindows;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace csY2S2_cs_project.Views
{
    /// <summary>
    /// Interaction logic for managerScreen.xaml
    /// </summary>
    public partial class managerScreen : Window
    {
        public managerScreen()
        {
            InitializeComponent();
            
        }


        private void manageBtn_Clicked(object sender, RoutedEventArgs e)
        {
            DataContext = new manageUserControl();
            
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            var LogedInUser = LogIn.currenUser;
            info.Text = LogedInUser.DisInformation();
            try
            {
                UserImage.ImageSource = new BitmapImage(new Uri("pack://application:,,,/csY2S2-cs-project;component" + LogedInUser.image, UriKind.RelativeOrAbsolute));
                
      
            }
            catch (Exception)
            {

                UserImage.ImageSource = new BitmapImage(new Uri("pack://application:,,,/csY2S2-cs-project;component/images/users/default.jpg", UriKind.RelativeOrAbsolute));
            }

           

        }
        

        private void dashboard_Click(object sender, RoutedEventArgs e)
        {
            DataContext = new dashBoardUserControl1();
        }

    

        private void logoutBtn_Click(object sender, RoutedEventArgs e)
        {

            this.Close();
        }

        

        private void productsBtn_Click(object sender, RoutedEventArgs e)
        {

            DataContext = new ProductsUserControl();
        }
    }
}
