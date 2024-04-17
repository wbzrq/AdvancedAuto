//using AdvancedAuto.database;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
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
        int totalPrice = 0;

        int id = 0;

        List<string> imgsPath = new List<string>();
        List<string> colors = new List<string>();

        public ConfiguratorWindow(string currentBrand, string currentModel)
        {
            //this.WindowState = System.Windows.WindowState.Maximized;
            InitializeComponent();
            this.currentAuto = currentBrand + currentModel;
            //CreateImages();
            /*AdvancedautoContext context = new AdvancedautoContext();
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

            txtCarTitle.Text = ConvertToTitleCase(currentBrand) + " " + ConvertToTitleCase(currentModel);
            totalPrice = Price(currentAuto);
            txtCarPrice.Text = totalPrice.ToString();

            CreateImg();*/
        }

        public int Price(string currentCar)
        {
            switch(currentCar)
            {
                case "porsche911":
                    return 554000;
                case "porschecayenne":
                    return 330000;
                case "porschepanamera":
                    return 420000;
                case "porschetaycan":
                    return 504000;
                default:
                    return 0;
            }
        }

        public string ConvertToTitleCase(string text)
        {
            return System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(text.ToLower());
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
                    return Color.FromRgb(64, 136, 72);
            }
            return Color.FromRgb(0, 0, 0);
        }

        public void CreateImg()
        {
            spCarImg.Children.Clear();
            Image img = new Image();
            img.Source = new BitmapImage(new Uri(imgsPath[id], UriKind.Relative));
            spCarImg.Children.Add(img);
            txtCarPrice.Text = (totalPrice + wheelPrice + colorPrice + interiorPrice).ToString();
        }

        /*public void CreateImages()
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
                MessageBox.Show("Ошибка загрузки автомобиля");
            }
        }*/


        private void tmpbtn_Click(object sender, RoutedEventArgs e)
        {
            if (id == 2)
                id = 0;
            else
                id++;
            //CreateImg();
        }

        int wheelPrice = 0;
        private void imgWheel1_MouseDown(object sender, MouseButtonEventArgs e)
        {
            currentWheel = "1";
            wheelPrice = 0;
            //CreateImages();
        }

        private void imgWheel2_MouseDown(object sender, MouseButtonEventArgs e)
        {
            currentWheel = "2";
            wheelPrice = 1500;
            //CreateImages();
        }

        private void imgWheel3_MouseDown(object sender, MouseButtonEventArgs e)
        {
            currentWheel = "3";
            wheelPrice = 4500;
            //CreateImages();
        }

        private void imgWheel4_MouseDown(object sender, MouseButtonEventArgs e)
        {
            currentWheel = "4";
            wheelPrice = 3500;
            //CreateImages();
        }

        int colorPrice = 0;
        private void imgColor1_MouseDown(object sender, MouseButtonEventArgs e)
        {
            currentColor = colors[0];
            colorPrice = 0;
            //CreateImages();
        }

        private void imgColor2_MouseDown(object sender, MouseButtonEventArgs e)
        {
            currentColor = colors[1];
            wheelPrice = 10500;
            //CreateImages();
        }

        private void imgColor3_MouseDown(object sender, MouseButtonEventArgs e)
        {
            currentColor = colors[2];
            wheelPrice = 15000;
            //CreateImages();
        }

        private void imgColor4_MouseDown(object sender, MouseButtonEventArgs e)
        {
            currentColor = colors[3];
            wheelPrice = 8500;
            //CreateImages();
        }

        private void txtLikedConfigurations_MouseEnter(object sender, MouseEventArgs e)
        {
            txtLikedConfigurations.TextDecorations = TextDecorations.Underline;
        }

        private void txtLikedConfigurations_MouseLeave(object sender, MouseEventArgs e)
        {
            txtLikedConfigurations.TextDecorations = null;
        }

        private void txtSwitchTheme_MouseEnter(object sender, MouseEventArgs e)
        {
            txtSwitchTheme.TextDecorations = TextDecorations.Underline;
        }

        private void txtSwitchTheme_MouseLeave(object sender, MouseEventArgs e)
        {
            txtSwitchTheme.TextDecorations = null;
        }

        private void txtSwitchAccount_MouseEnter(object sender, MouseEventArgs e)
        {
            txtSwitchAccount.TextDecorations = TextDecorations.Underline;
        }

        private void txtSwitchAccount_MouseLeave(object sender, MouseEventArgs e)
        {
            txtSwitchAccount.TextDecorations = null;
        }

        private void txtSwitchAccount_MouseDown(object sender, MouseButtonEventArgs e)
        {
            AuthWindow authWindow = new AuthWindow();
            authWindow.Show();
            this.Hide();
        }

        bool isMenuHidden = true;
        private void imgProfile_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (isMenuHidden) grdProfileMenu.Visibility = Visibility.Visible;
            else grdProfileMenu.Visibility = Visibility.Visible;
            isMenuHidden = !isMenuHidden;
        }

        private void imgClose_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Environment.Exit(0);
        }

        int interiorPrice = 0;
        private void imgInterior1_MouseDown(object sender, MouseButtonEventArgs e)
        {
            currentInterior = "1";
            interiorPrice = 0;
            id = 2;
            //CreateImages();
        }

        private void imgInterior2_MouseDown(object sender, MouseButtonEventArgs e)
        {
            currentInterior = "2";
            wheelPrice = 5000;
            id = 2;
            //CreateImages();
        }

        private void imgInterior3_MouseDown(object sender, MouseButtonEventArgs e)
        {
            currentInterior = "3";
            wheelPrice = 8000;
            id = 2;
            // CreateImages();
        }

        private void imgInterior4_MouseDown(object sender, MouseButtonEventArgs e)
        {
            currentInterior = "4";
            wheelPrice = 9100;
            id = 2;
            //CreateImages();
        }

        private void btnToEmail_Click(object sender, RoutedEventArgs e)
        {

            //SendMailWithAttachments("1216309@mtp.by", "тест", "алдвавыаодлж", imgsPath);
        }

        bool isConfLiked = false;
        private void imgLike_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (isConfLiked)
            {
                imgLike.Source = new BitmapImage(new Uri("/images/unshaded_star_icon.png", UriKind.Relative));
            }
            else
            {
                imgLike.Source = new BitmapImage(new Uri("/images/shaded_star_icon.png", UriKind.Relative));
            }
            isConfLiked = !isConfLiked;
        }

        /*public void SendMailWithAttachments(string recipientEmail, string subject, string text, List<string> attachmentPaths)
        {
            MailMessage mail = new MailMessage();
            SmtpClient SmtpServer = new SmtpClient("smtp.mail.ru");

            // Указываем отправителя и получателя
            mail.From = new MailAddress("ravil.ilchibaev@mail.ru");
            mail.To.Add(recipientEmail);

            // Задаем тему и текст письма
            mail.Subject = subject;
            mail.Body = text;

            // Добавляем все указанные вложения
            //foreach (var attachmentPath in attachmentPaths)
            //{
            //    System.Net.Mail.Attachment attachment = new System.Net.Mail.Attachment("C:\\\\MCB\\\\УПпП\\\\Project\\\\AdvancedAuto\\\\AdvancedAuto\\" + attachmentPath);
            //    mail.Attachments.Add(attachment);
            //}

            // Конфигурация и подключение к SMTP-серверу
            SmtpServer.Port = 465;   //  Ваш порт может отличаться
            SmtpServer.Credentials = new System.Net.NetworkCredential("advancedauto", "5gZqaV6kHKW5YZtq1D0Q");
            SmtpServer.EnableSsl = true;

            // Отправка письма
            SmtpServer.Send(mail);
            MessageBox.Show("успешно");
        }*/
    }
}
