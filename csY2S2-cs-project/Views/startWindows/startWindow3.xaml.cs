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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace csY2S2_cs_project.Views.startWindows
{
    /// <summary>
    /// Interaction logic for startWindow3.xaml
    /// </summary>
    public partial class startWindow3 : Page
    {
        public startWindow3()
        {
            InitializeComponent();
        }
        private void Previous_button_clicked(object sender, RoutedEventArgs e)
        {
            //got to page 2 
            this.NavigationService.Navigate(new startWindow2());
        }


        private void Start_Button_Click(object sender, RoutedEventArgs e)
        {
            //change startWindow3 to the log in window so the user can log in as a accountant/casher or a manager  
            this.NavigationService.Navigate(new LogIn());
        }
    }
}
