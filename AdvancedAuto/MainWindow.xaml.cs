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
            for (int i = 0; i < 5; i++)
            {
                Image img = new Image();
                img.Source = new BitmapImage(new Uri("AutoImg/teaserAutoImg/porsche_911.jpg", UriKind.Relative));
                img.Width = 50;
                img.Height = 50;
                wpListAuto.Children.Add(img);
            }
            
        }
    }
}
