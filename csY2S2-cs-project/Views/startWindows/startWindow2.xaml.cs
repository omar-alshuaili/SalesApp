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
    /// Interaction logic for startWindow2.xaml
    /// </summary>
    public partial class startWindow2 : Page
    {
        public startWindow2()
        {
            InitializeComponent();
        }
        private void Next_button_clicked(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new startWindow3());

        }

        private void Previous_button_clicked(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new startWindow1());

        }
    }
}
