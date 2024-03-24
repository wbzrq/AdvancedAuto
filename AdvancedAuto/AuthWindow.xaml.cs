using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
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

namespace AdvancedAuto
{
    public partial class AuthWindow : Window
    {
        public AuthWindow()
        {
            InitializeComponent();
        }

        private void textLogin_MouseDown(object sender, MouseButtonEventArgs e)
        {
            txtLogin.Focus();
        }

        private void txtLogin_TextChanged(object sender, TextChangedEventArgs e)
        {
            if(!string.IsNullOrEmpty(txtLogin.Text) && txtLogin.Text.Length > 0)
            {
                textLogin.Visibility = Visibility.Collapsed;
            }
            else
            {
                textLogin.Visibility = Visibility.Visible;
            }
        }

        private void textPass_MouseDown(object sender, MouseButtonEventArgs e)
        {
            txtPass.Focus();
        }

        private void txtPass_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtPass.Password) && txtPass.Password.Length > 0)
            {
                textPass.Visibility = Visibility.Collapsed;
            }
            else
            {
                textPass.Visibility = Visibility.Visible;
            }
        }

        bool isPasswordShow = false;
        private void Image_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (isPasswordShow)
            {
                imgLock.Source = new BitmapImage(new Uri("/Images/lock_close_icon.png", UriKind.Relative));
            }
            else
            {
                imgLock.Source = new BitmapImage(new Uri("/Images/lock_open_icon.png", UriKind.Relative));
            }
            isPasswordShow = !isPasswordShow;
        }

        private void btnLogIn_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void btnToSignUp_Click(object sender, RoutedEventArgs e)
        {
            if (grdSignIn.Visibility != Visibility.Hidden)
            {
                grdSignIn.Visibility = Visibility.Hidden;
                grdSignUp.Visibility = Visibility.Visible;
            }
            else
            {
                grdSignIn.Visibility = Visibility.Visible;
                grdSignUp.Visibility = Visibility.Hidden;
            }
            
        }

        private void textNewLogin_MouseDown(object sender, MouseButtonEventArgs e)
        {
            txtNewLogin.Focus();
        }

        private void txtNewLogin_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtNewLogin.Text) && txtNewLogin.Text.Length > 0)
            {
                textNewLogin.Visibility = Visibility.Collapsed;
            }
            else
            {
                textNewLogin.Visibility = Visibility.Visible;
            }
        }

        private void textNewPass_MouseDown(object sender, MouseButtonEventArgs e)
        {
            txtNewPass.Focus();
        }

        private void txtNewPass_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtNewPass.Password) && txtNewPass.Password.Length > 0)
                textNewPass.Visibility = Visibility.Collapsed;
            else
                textNewPass.Visibility = Visibility.Visible;
        }

        private void textPassConf_MouseDown(object sender, MouseButtonEventArgs e)
        {
            txtPassConf.Focus();
        }

        private void txtPassConf_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtPassConf.Password) && txtPassConf.Password.Length > 0)
                textPassConf.Visibility = Visibility.Collapsed;
            else
                textPassConf.Visibility = Visibility.Visible;
        }
    }
}
