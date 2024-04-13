using AdvancedAuto.database;
using Microsoft.EntityFrameworkCore.Diagnostics;
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
    public partial class ConfiguratorWindow : Window
    {
        string currentAuto;
        string currentColor = "black";
        string currentWheel = "1";
        string currentInterior = "1";

        int id = 0;

        List<string> imgsPath = new List<string>();
        List<string> colors = new List<string>();

        public ConfiguratorWindow(string currentAuto)
        {
            InitializeComponent();
            this.currentAuto = currentAuto;
            CreateImages();
            AdvancedautoContext context = new AdvancedautoContext();
            imgWheel1.Source = new BitmapImage(new Uri(context.Teaserwheels.FirstOrDefault(x => x.Brand + x.Model == currentAuto && x.TwPath.Contains("1")).TwPath, UriKind.Relative));
            imgWheel2.Source = new BitmapImage(new Uri(context.Teaserwheels.FirstOrDefault(x => x.Brand + x.Model == currentAuto && x.TwPath.Contains("2")).TwPath, UriKind.Relative));
            imgWheel3.Source = new BitmapImage(new Uri(context.Teaserwheels.FirstOrDefault(x => x.Brand + x.Model == currentAuto && x.TwPath.Contains("3")).TwPath, UriKind.Relative));
            imgWheel4.Source = new BitmapImage(new Uri(context.Teaserwheels.FirstOrDefault(x => x.Brand + x.Model == currentAuto && x.TwPath.Contains("4")).TwPath, UriKind.Relative));

            var c = context.Carimages.Where(x => x.Brand + x.Model == currentAuto).ToList();

            colors = new List<string>
            {
                c[0].Color,
                c[8].Color,
                c[16].Color,
                c[24].Color
            };

            imgColor1.Fill = new SolidColorBrush(CreateColor(colors[0]));
            imgColor2.Fill = new SolidColorBrush(CreateColor(colors[1]));
            imgColor3.Fill = new SolidColorBrush(CreateColor(colors[2]));
            imgColor4.Fill = new SolidColorBrush(CreateColor(colors[3]));

            
            CreateImg();
        }

        public Color CreateColor(string color)
        {
            switch(color)
            {
                case "white":
                    return Color.FromRgb(239, 239, 239);
                case "black":
                    return Color.FromRgb(0, 0, 0);
                case "red":
                    return Color.FromRgb(204, 0, 51);
                case "yellow":
                    return Color.FromRgb(255, 204, 0);
                case "blue":
                    return Color.FromRgb(0, 0, 51);
                case "gray":
                    return Color.FromRgb(23, 26, 33);
                case "green":
                    return Color.FromRgb(23, 26, 33);
            }
            return Color.FromRgb(0, 0, 0);
        }

        public void CreateImg()
        {
            spCarImg.Children.Clear();
            Image img = new Image();
            img.Source = new BitmapImage(new Uri(imgsPath[id], UriKind.Relative));
            spCarImg.Children.Add(img);
        }

        public void CreateImages()
        {
            AdvancedautoContext context = new AdvancedautoContext();
            try
            {
                imgsPath = new List<string>
                {
                    context.Carimages.FirstOrDefault(x => x.Brand + x.Model == currentAuto && x.View == "front" && x.Color == currentColor && x.ImagePath.Contains(currentWheel)).ImagePath,
                    context.Carimages.FirstOrDefault(x => x.Brand + x.Model == currentAuto && x.View == "back" && x.Color == currentColor && x.ImagePath.Contains(currentWheel)).ImagePath,
                    context.Interiorimages.FirstOrDefault(x => x.Brand + x.Model == currentAuto && x.InteriorPath.Contains(currentInterior)).InteriorPath
                };
                CreateImg();
            }
            catch
            {

            }
        }


        private void tmpbtn_Click(object sender, RoutedEventArgs e)
        {
            if (id == 2)
                id = 0;
            else
                id++;
            CreateImg();
        }

        private void imgWheel1_MouseDown(object sender, MouseButtonEventArgs e)
        {
            currentWheel = "1";
            CreateImages();
        }

        private void imgWheel2_MouseDown(object sender, MouseButtonEventArgs e)
        {
            currentWheel = "2";
            CreateImages();
        }

        private void imgWheel3_MouseDown(object sender, MouseButtonEventArgs e)
        {
            currentWheel = "3";
            CreateImages();
        }

        private void imgWheel4_MouseDown(object sender, MouseButtonEventArgs e)
        {
            currentWheel = "4";
            CreateImages();
        }

        private void imgColor1_MouseDown(object sender, MouseButtonEventArgs e)
        {
            currentColor = colors[0];
            CreateImages();
        }

        private void imgColor2_MouseDown(object sender, MouseButtonEventArgs e)
        {
            currentColor = colors[1];
            CreateImages();
        }

        private void imgColor3_MouseDown(object sender, MouseButtonEventArgs e)
        {
            currentColor = colors[2];
            CreateImages();
        }

        private void imgColor4_MouseDown(object sender, MouseButtonEventArgs e)
        {
            currentColor = colors[3];
            CreateImages();
        }
    }
}
