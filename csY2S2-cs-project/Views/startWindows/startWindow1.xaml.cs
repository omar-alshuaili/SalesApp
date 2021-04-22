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
    /// Interaction logic for startWindow1.xaml
    /// </summary>
    public partial class startWindow1 : Page
    {
        public startWindow1()
        {
            InitializeComponent();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new startWindow2());
        }
    }
}
