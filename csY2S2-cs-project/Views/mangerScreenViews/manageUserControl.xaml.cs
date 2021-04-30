using System;
using System.Collections.Generic;
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
using csY2S2_cs_project.classes;
using System.Timers;
using System.Windows.Threading;

namespace csY2S2_cs_project.Views.mangerScreenViews
{
    /// <summary>
    /// Interaction logic for manageUserControl.xaml
    /// </summary>
    public partial class manageUserControl : UserControl
    {


        public static List<CashierClass> cashiers = new List<CashierClass>();

        public manageUserControl()
        {
            InitializeComponent();


        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {

            nameInput.IsEnabled = false;
            passwordInput.IsEnabled = false;
            roleNameInput.IsEnabled = false;

            //creating CashierClass objects
            CashierClass c1 = new CashierClass(name: "Jimmy Townsend", roleName: "cashier", image: "/images/users/Jimmy.jpg", password: "g89oihadv");
            CashierClass c2 = new CashierClass(name: "Daniele Zamora", roleName: "cashier", image: "/images/users/Daniele.jpg", password: "sjfhsd3");
            CashierClass c3 = new CashierClass(name: "Nell Mueller", roleName: "cashier", image: "/images/users/Nell.jpg", password: "jdkeshdui3");
            CashierClass c4 = new CashierClass(name: "Zayden Ortiz", roleName: "cashier", image: "/images/users/Zayden.jpg", password: "34hhudh");
            CashierClass c5 = new CashierClass(name: "Devante Cannon", roleName: "cashier", image: "/images/users/Devante.jpg", password: "34hjkdxxx");
            CashierClass c6 = new CashierClass(name: "Findlay Nash", roleName: "cashier", image: "/images/users/Findlay.jpg", password: "98hfd87");
            CashierClass c7 = new CashierClass(name: "Darcy Proctor", roleName: "cashier", image: "/images/users/Darcy.jpg", password: "ndjkhf89");
            CashierClass c8 = new CashierClass(name: "Raymond Mercer", roleName: "cashier", image: "/images/users/Raymond.jpg", password: "wdhjwh112");

            //adding the objects to the list
            cashiers.Add(c1);
            cashiers.Add(c2);
            cashiers.Add(c3);
            cashiers.Add(c4);
            cashiers.Add(c5);
            cashiers.Add(c6);
            cashiers.Add(c7);
            cashiers.Add(c8);

            //updatig the list box 
            usersListBox.ItemsSource = cashiers;



        }

        //just simpol method to enable or disable the inputs field 
        public void Enabled(Boolean enable)
        {
            if (enable)
            {
                nameInput.IsEnabled = true;
                passwordInput.IsEnabled = true;
                roleNameInput.IsEnabled = true;

            }
            else
            {
                nameInput.IsEnabled = false;
                passwordInput.IsEnabled = false;
                roleNameInput.IsEnabled = false;
            }

        }

        public Boolean isEnabled()
        {
            if (nameInput.IsEnabled == false && passwordInput.IsEnabled == false && roleNameInput.IsEnabled == false)
            {
                
                waringMessage.Visibility = Visibility.Visible;
                hide.Visibility = Visibility.Visible;

                return false;
            }
            else
            {
                return true;
            }


        }

        //update the inptus text according to the selected item 
        private void usersListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            

            //getting the selected item as an object of type CashierClass
            CashierClass selectedItem = usersListBox.SelectedItem as CashierClass;

            Enabled(false);
            nameInput.Text = string.Empty;
            passwordInput.Text = string.Empty;
            roleNameInput.Text = string.Empty;


            //to handel null object exception 
            if (selectedItem != null)
            {
               
                nameInput.Text = selectedItem.Name;
                passwordInput.Text = selectedItem.Password;
                roleNameInput.Text = selectedItem.RoleName;

            }
           
           

        }

        //the edit button event 
        private void editBtn_Click(object sender, RoutedEventArgs e)
        {
            //pass true into the Enable() method which will enable the inputs so they can be modified 
            if (usersListBox.SelectedItem != null)
            {
                Enabled(true);
            }
            else
            {
                MessageBox.Show("Please select user to edit");
            }


        }

        // these 3 methods are checking if the inputs are enabled 
        //if no and user touch the inputs a warning message will be displayed
        //if yes and the user touch the inputs a warning message will be hidden and the user can and edit 
        private void nameInput_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (!isEnabled())
            {
                waringMessage.Visibility = Visibility.Visible;
                hide.Visibility = Visibility.Visible;

            }
            else
            {
                waringMessage.Visibility = Visibility.Hidden;
                hide.Visibility = Visibility.Hidden;

            }

        }
        private void passwordInput_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (!isEnabled())
            {
                waringMessage.Visibility = Visibility.Visible;
                hide.Visibility = Visibility.Visible;

            }
            else
            {
                waringMessage.Visibility = Visibility.Hidden;
                hide.Visibility = Visibility.Hidden;

            }
        }

        private void roleNameInput_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (!isEnabled())
            {
                waringMessage.Visibility = Visibility.Visible;
                hide.Visibility = Visibility.Visible;

            }
            else
            {
                waringMessage.Visibility = Visibility.Hidden;
                hide.Visibility = Visibility.Hidden;

            }

        }


        //this method handles the warning message
        private void Warning(string nameOfInput)
        {
           
            switch (nameOfInput)
            {

                case "roleNameInput":
                    {
                        waringMessage.Text = "Role name can be either cashier or manager";
                        waringMessage.Visibility = Visibility.Visible;
                        hide.Visibility = Visibility.Visible;

                        break;
                    }
                case "passwordInput":
                    {
                        waringMessage.Text = waringMessage.Text = "Make sure you entered password !!";
                        waringMessage.Visibility = Visibility.Visible;
                        hide.Visibility = Visibility.Visible;

                        break;
                    }
                default:
                    waringMessage.Text = "Sorry, but no one has an empty name !!";
                    waringMessage.Visibility = Visibility.Visible;
                    hide.Visibility = Visibility.Visible;

                    break;
            }
        }



        private void validation()
        {
            //getting the selected item as an object of type CashierClass
            CashierClass selectedItem = usersListBox.SelectedItem as CashierClass;
            if (selectedItem != null)
            {



                if (string.IsNullOrEmpty(nameInput.Text))
                {
                    Warning(nameInput.Name);
                }
                else
                {
                    selectedItem.Name = nameInput.Text;
                }


                if (string.IsNullOrEmpty(passwordInput.Text))
                {
                    Warning(passwordInput.Name);

                }
                else
                {
                    selectedItem.Password = passwordInput.Text;
                }


                if (roleNameInput.Text.ToLower() == "manager" || roleNameInput.Text.ToLower() == "cashier")
                {
                    selectedItem.RoleName = roleNameInput.Text.ToLower();

                }
                else
                {
                    Warning(roleNameInput.Name);

                }
            }



        }


        // hide the warning message 
        private void hide_Click(object sender, RoutedEventArgs e)
        {
            waringMessage.Visibility = Visibility.Hidden;
            hide.Visibility = Visibility.Hidden;
        }


        //save button event
        private void saveBtn_Click(object sender, RoutedEventArgs e)
        {
            //if the inputs are not enabled (the edit button not pressed) a warning message will be displayed 
            if (isEnabled())
            {
               
                waringMessage.Visibility = Visibility.Hidden;
                hide.Visibility = Visibility.Hidden;
                validation();
                updateList(cashiers);

            }
        }



        private void deleteBtn_Click(object sender, RoutedEventArgs e)
        {
            CashierClass selectedItem = usersListBox.SelectedItem as CashierClass;
            cashiers.Remove(selectedItem);
            updateList(cashiers);

        }

        public void updateList(List<CashierClass> cashiers)
        {
            usersListBox.ItemsSource = null;
            usersListBox.ItemsSource = cashiers;

        }
    }
}
