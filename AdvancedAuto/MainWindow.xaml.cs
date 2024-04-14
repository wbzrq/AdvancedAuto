//using AdvancedAuto.database;
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

namespace AdvancedAuto
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            //CreateImgs();

        }

        private void imgClose_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Environment.Exit(0);
        }

        bool isMenuHidden = true;
        private void imgProfile_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (isMenuHidden) grdProfileMenu.Visibility = Visibility.Visible;
            else grdProfileMenu.Visibility = Visibility.Hidden;
            isMenuHidden = !isMenuHidden;
        }

        private void txtSwitchAccount_MouseDown(object sender, MouseButtonEventArgs e)
        {
            AuthWindow authWindow = new AuthWindow();
            authWindow.Show();
            this.Hide();
        }

        private void txtSwitchAccount_MouseEnter(object sender, MouseEventArgs e)
        {
            txtSwitchAccount.TextDecorations = TextDecorations.Underline;
        }

        private void txtSwitchAccount_MouseLeave(object sender, MouseEventArgs e)
        {
            txtSwitchAccount.TextDecorations = null;
        }

        private void txtSwitchTheme_MouseEnter(object sender, MouseEventArgs e)
        {
            txtSwitchTheme.TextDecorations = TextDecorations.Underline;
        }

        private void txtSwitchTheme_MouseLeave(object sender, MouseEventArgs e)
        {
            txtSwitchTheme.TextDecorations = null;
        }

        private void txtLikedConfigurations_MouseEnter(object sender, MouseEventArgs e)
        {
            txtLikedConfigurations.TextDecorations = TextDecorations.Underline;
        }

        private void txtLikedConfigurations_MouseLeave(object sender, MouseEventArgs e)
        {
            txtLikedConfigurations.TextDecorations = null;
        }

        /*public void CreateImgs()
        {
            AdvancedautoContext context = new AdvancedautoContext();
            var teaserAutoInfo = context.Teaserautos.ToList();
            foreach (var auto in teaserAutoInfo)
            {
                StackPanel stack = new StackPanel();
                stack.Orientation = Orientation.Vertical;
                Border border = new Border();
                border.BorderThickness = new Thickness(1);
                border.CornerRadius = new CornerRadius(10);
                border.Margin = new Thickness(10);
                border.Child = stack;

                Image img = new Image();
                img.Source = new BitmapImage(new Uri(auto.ImagePath, UriKind.Relative));
                img.Width = 160;
                img.Height = 90;
                img.Margin = new Thickness(5);
                stack.Children.Add(img);

                TextBlock textBlock = new TextBlock();
                textBlock.HorizontalAlignment = HorizontalAlignment.Center;
                textBlock.Text = ConvertToTitleCase(auto.Brand) + " " + ConvertToTitleCase(auto.Model);
                stack.Children.Add(textBlock);

                wpListAuto.Children.Add(border);

                stack.MouseEnter += (s, e) => { border.BorderBrush = new SolidColorBrush(Colors.LightGray); };
                stack.MouseLeave += (s, e) => { border.BorderBrush = new SolidColorBrush(Colors.White); };

                stack.MouseLeftButtonDown += (s, e) =>
                {
                    ConfiguratorWindow configuratorWindow = new ConfiguratorWindow(auto.Brand + auto.Model);
                    configuratorWindow.Show();
                    this.Hide();
                };
            }
        }

        public string ConvertToTitleCase(string text)
        {
            return System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(text.ToLower());
        }*/
    }
}
