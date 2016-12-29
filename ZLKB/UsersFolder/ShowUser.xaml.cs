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

namespace ZLKB.UsersFolder
{
    /// <summary>
    /// Interaction logic for ShowUser.xaml
    /// </summary>
    public partial class ShowUser : Window
    {
        string exepath = Environment.CurrentDirectory;
        public ShowUser()
        {
            InitializeComponent();
            HomeIconImage.Source = new BitmapImage(new Uri(exepath + @"\Data\Images\Buttons\home.png"));
            PhoneIconImage.Source = new BitmapImage(new Uri(exepath + @"\Data\Images\Buttons\phone.png"));
            MailIconImage.Source = new BitmapImage(new Uri(exepath + @"\Data\Images\Buttons\mail.png"));
        }

        private void Label_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }
    }
}
