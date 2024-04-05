using AdvancedAuto.database;
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
            CreateImgs();
        }

        public void CreateImgs()
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

                
            }
        }

        public string ConvertToTitleCase(string text)
        {
            return System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(text.ToLower());
        }
    }
}
