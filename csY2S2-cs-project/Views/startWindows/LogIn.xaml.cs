using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using csY2S2_cs_project.classes;
using csY2S2_cs_project.Data;

namespace csY2S2_cs_project.Views.startWindows
{
    /// <summary>
    /// Interaction logic for LogIn.xaml
    /// </summary>
    public partial class LogIn : Page
    {
        Model1Container db = new Model1Container();

        public LogIn()
        {
            InitializeComponent();
        }






        public void Button_Click(object sender, RoutedEventArgs e)
        {


            managerScreen managerScreen = new managerScreen();
            managerScreen.Show();

            MainWindow win = new MainWindow();
            win.Close();


            var query = from t in db.users
                        select t.name;

            var result = query.ToList().First();

            text.Text = result.ToString();

            //var q = from u in db.users
            //        where u.password == passwordInput.Text.ToString()
            //        select u;


            //var results = q.ToList();

            //foreach (var item in results)
            //{

            //    if (item.roleId.ToString() == "1")
            //    {
            //        CashierClass c = new CashierClass();
            //        c.Name = item.name.ToString();
            //        c.image = item.image;
            //        CurrentUser u = new CurrentUser();
            //        u.User(c);

            //    }
            //    else
            //    {
            //        managerClass m = new managerClass();
            //        m.Name = item.name.ToString();
            //        m.image = item.image;
            //        CurrentUser u = new CurrentUser();
            //        u.User(m);
            //    }

            //}







        }
        public class CurrentUser
        {
            public string User(UserClass user)
            {
                return user.Name;
            }

        }
    }

}
