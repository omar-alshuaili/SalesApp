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

        public static List<managerClass> Managerusers = new List<managerClass>();





        Model1Container db = new Model1Container();

        public LogIn()
        {
            InitializeComponent();
        }






        public void Button_Click(object sender, RoutedEventArgs e)
        {




            MainWindow win = new MainWindow();
            win.Close();

            //get the user fileds from the database 
            var UserQuery = from u in db.users
                            where u.userName == userNameInput.Text
                            select u;

            //get the userName password and check if it is correct
            var PasswordQuery = from p in UserQuery
                                where p.password == passwordInput.Text
                                select new
                                {
                                    userName = p.userName,
                                    password = p.password,
                                    name = p.name,
                                    image = p.image,
                                    role = p.roleId
                                };


            //check if passwordInput is null
            try
            {

                var currenUser = PasswordQuery.ToList().First();

                if (currenUser.role == 1)
                {

                    Managerusers.Add(new managerClass { Name = currenUser.name.ToString(), Password = currenUser.password.ToString(), RoleName = "manager", image = currenUser.image.ToString() });
                    

                    managerScreen managerScreen = new managerScreen();
                    managerScreen.Show();
                }

            }
            catch (Exception)
            {

                message.Text = "Please enter valid password";
            }


        }



    }

}
