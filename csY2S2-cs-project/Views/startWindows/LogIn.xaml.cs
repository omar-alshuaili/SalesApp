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

        public static managerClass currenUser = new managerClass();





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
                                    ImageURI = p.image,
                                    role = p.roleId
                                };


            //check if passwordInput is null
            try
            {

                var Manager = PasswordQuery.ToList().First();

                if (Manager.role == 1)
                {



                    currenUser.Name = Manager.name.ToString();
                    currenUser.Password = Manager.password.ToString();
                    currenUser.RoleName = "manager";
                    currenUser.image = Manager.ImageURI;

                    try
                    {
                        managerScreen managerScreen = new managerScreen();
                        managerScreen.Show();
                    }
                    catch 
                    {

           
                    }
                   
                }

            }
            catch (Exception)
            {

                message.Text = "Please enter valid password";
            }


        }



    }

}
