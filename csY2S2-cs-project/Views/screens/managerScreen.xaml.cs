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


        private void SalesBtn_Clicked(object sender, RoutedEventArgs e)
        {
            DataContext = new salesUserControl();
        }
        public void  users()
        {
            LogIn.CurrentUser user = new LogIn.CurrentUser();
            
        }
    }
}
