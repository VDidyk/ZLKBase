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
using System.Threading;
namespace ZLKB.UsersFolder
{
    delegate void LoadDelegate();
    public partial class AddUserWindow : Window
    {
        string exepath = Environment.CurrentDirectory;
        
        public AddUserWindow()
        {
            InitializeComponent();
            this.Dispatcher.BeginInvoke(new LoadDelegate(LoadAll), null);
            //Картинка Добавить Клиента
            SaveButtonImage.Source = new BitmapImage(new Uri(exepath + @"\Data\Images\Buttons\save.png"));
            CancelButtonImage.Source = new BitmapImage(new Uri(exepath + @"\Data\Images\Buttons\delete.png"));
        }
        //Кнопка отмены
        private void CancelButton_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        void LoadAll()
        {
           
        }
    }
}
