using AdvancedAuto.database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Text.RegularExpressions;
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
        bool isSignIn = true;
        public AuthWindow()
        {
            InitializeComponent();
            //this.WindowState = System.Windows.WindowState.Maximized;
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
            AdvancedautoContext context = new AdvancedautoContext();
            if (txtLogin.Text.Equals(String.Empty)) MessageBox.Show("Введите логин");
            else if (txtPass.Password.Equals(String.Empty)) MessageBox.Show("Введите пароль");
            else if(context.Users.FirstOrDefault(x => x.Login == txtLogin.Text && x.Pass == txtPass.Password) != null)
            {
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
                this.Hide();
            }
            else if (context.Users.FirstOrDefault(x => x.Login == txtLogin.Text) != null) MessageBox.Show("Пароль неверный");
            else MessageBox.Show("Пользователь с таким логином не существует");
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

        private void btnSignUp_Click(object sender, RoutedEventArgs e)
        {
            AdvancedautoContext context = new AdvancedautoContext();
            if (txtNewLogin.Text.Equals(String.Empty)) MessageBox.Show("Заполните поле логина");
            else if (txtNewPass.Password.Equals(String.Empty)) MessageBox.Show("Заполните поле пароля");
            else if (txtPassConf.Password.Equals(String.Empty)) MessageBox.Show("Подтвердите пароль");
            else if (txtNewPass.Password != txtPassConf.Password) MessageBox.Show("Пароли не совпадают");
            else if (context.Users.FirstOrDefault(x => x.Login == txtNewLogin.Text) != null) MessageBox.Show("Данный логин уже занят");
            else if(!ValidateLogin(txtNewLogin.Text)) MessageBox.Show("Логин должен быть от 5 до 10 символов, состоять только из латинских символов и цифр");
            else if (!ValidatePassword(txtNewPass.Password)) MessageBox.Show("Пароль должен быть от 10 до 20 символов, состоять только из латинских символов, цифр и специальных символов");
            else
            {
                var user = new User() { Login = txtNewLogin.Text, Pass = txtNewPass.Password };
                context.Users.Add(user);
                context.SaveChanges();
                grdSignUp.Visibility = Visibility.Hidden;
                grdSignIn.Visibility = Visibility.Visible;
                txtLogin.Text = user.Login;
                txtNewLogin.Clear();
                txtNewPass.Clear();
                txtPassConf.Clear();
            }

        }

        public bool ValidateLogin(string login)
        {
            const string Pattern = "^[a-zA-Z0-9]{5,20}$";
            return Regex.IsMatch(login, Pattern);
        }

        public bool ValidatePassword(string password)
        {
            const string Pattern = "^[a-zA-Z0-9@#$%^&+=]{10,20}$";
            return Regex.IsMatch(password, Pattern);
        }
    }
}
