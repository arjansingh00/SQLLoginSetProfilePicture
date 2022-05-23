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
using System.Data;

namespace SQLLoginSetProfilePicture
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public bool loginFlag { get; set; }

        public int UserID { get; set; }

        public String userName { get; set; }

        public LoginWindow()
        {
            InitializeComponent();
            loginFlag = false;
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            DataSet1TableAdapters.UsersTableAdapter userAda = new DataSet1TableAdapters.UsersTableAdapter();
            DataTable dt = userAda.GetDataByUserAndPass(UserNameTextBox.Text, PasswordTextBox.Text);

            if(dt.Rows.Count > 0)
            {
                //There is data
                UserID = int.Parse(dt.Rows[0]["UserID"].ToString());
                userName = dt.Rows[0]["UserName"].ToString();
                loginFlag = true;
                Close();
            }
            else
            {
                //No data
                loginFlag = false;
                EnterUserPasswordName.Foreground = Brushes.Red;
                EnterUserPasswordName.Content = "Username or Password incorrect";
            }
        }

        private void UserNameTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                if ((String.IsNullOrEmpty(UserNameTextBox.Text)) && (String.IsNullOrEmpty(PasswordTextBox.Text)))
                {
                    EnterUserPasswordName.Content = "Enter Username & Password";
                }
                else if (String.IsNullOrEmpty(PasswordTextBox.Text))
                {
                    EnterUserPasswordName.Content = "Enter Password";
                }
                else if ((String.IsNullOrEmpty(UserNameTextBox.Text)))
                {
                    EnterUserPasswordName.Content = "Enter Username";
                }
                else
                {
                    Login_Click(sender, e);
                }
            }
        }

        private void PasswordTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                if ((String.IsNullOrEmpty(UserNameTextBox.Text)) && (String.IsNullOrEmpty(PasswordTextBox.Text)))
                {
                    EnterUserPasswordName.Content = "Enter Username & Password";
                }
                else if (String.IsNullOrEmpty(PasswordTextBox.Text))
                {
                    EnterUserPasswordName.Content = "Enter Password";
                }
                else if ((String.IsNullOrEmpty(UserNameTextBox.Text)))
                {
                    EnterUserPasswordName.Content = "Enter Username";
                }
                else
                {
                    Login_Click(sender, e);
                }
            }
        }
    }
}
