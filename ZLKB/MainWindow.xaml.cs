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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Threading;
namespace ZLKB
{
    //Делегат метода загрузки картинок
    delegate void LoadImagesDelegate();
    public partial class MainWindow : Window
    {
        string exepath = Environment.CurrentDirectory;
        List<Grid> grids = new List<Grid>();
        public MainWindow()
        {
            try
            {
                InitializeComponent();
                grids.Add(MainGrid);
                Begin();
                Other.Phone ph = new Other.Phone("0506548465");
                
            }
            catch(Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }
        //Метод начала
        void Begin()
        {
            //Загрузка картинок
            this.Dispatcher.BeginInvoke(new LoadImagesDelegate(LoadImages), null);
        }
        /// <summary>
        /// Загрузка картинок
        /// </summary>
        void LoadImages()
        {
            //Картинка Добавить Клиента
            CreateClientButtonImage.Source = new BitmapImage(new Uri(exepath + @"\Data\Images\Buttons\add.png"));
            //Картинка Показать Клиентов
            ShowClientButtonImage.Source = new BitmapImage(new Uri(exepath + @"\Data\Images\Buttons\show.png"));
            //Картинка Найти Клиента
            FindClientButtonImage.Source = new BitmapImage(new Uri(exepath + @"\Data\Images\Buttons\find.png"));
            //Картинка Создать Запрос
            CreateRequestButtonImage.Source = new BitmapImage(new Uri(exepath + @"\Data\Images\Buttons\add.png"));
            //Картинка Показать Запросы
            ShowRequestButtonImage.Source = new BitmapImage(new Uri(exepath + @"\Data\Images\Buttons\show.png"));
            //Картинка Найти Запрос
            FindRequestButtonImage.Source = new BitmapImage(new Uri(exepath + @"\Data\Images\Buttons\find.png"));
            //Картинка Добавить Поставщика
            AddSupplierButtonImage.Source = new BitmapImage(new Uri(exepath + @"\Data\Images\Buttons\add.png"));
            //Картинка Найти Поставщика
            FindSupplierButtonImage.Source = new BitmapImage(new Uri(exepath + @"\Data\Images\Buttons\find.png"));
            //Картинка Показать Поставщиков
            ShowSupplierButtonImage.Source = new BitmapImage(new Uri(exepath + @"\Data\Images\Buttons\show.png"));
            //Картинка Показать Отправки
            ShowShippingsButtonImage.Source = new BitmapImage(new Uri(exepath + @"\Data\Images\Buttons\list.png"));
            //Картинка Создать Отправку
            AddShippingButtonImage.Source = new BitmapImage(new Uri(exepath + @"\Data\Images\Buttons\add.png"));
            //Картинка Найти Отправку
            FindShippingButtonImage.Source = new BitmapImage(new Uri(exepath + @"\Data\Images\Buttons\find.png"));
            //Картинка Показать Пользователей
            ShowUsersButtonImage.Source = new BitmapImage(new Uri(exepath + @"\Data\Images\Buttons\show.png"));
            //Картинка Добавить Пользователей
            AddUsersButtonImage.Source = new BitmapImage(new Uri(exepath + @"\Data\Images\Buttons\add.png"));
            //Картинка Поиск Пользователей
            FindUsersButtonImage.Source = new BitmapImage(new Uri(exepath + @"\Data\Images\Buttons\find.png"));
            //Картинка Настройки
            ConfigurationButtonImage.Source = new BitmapImage(new Uri(exepath + @"\Data\Images\Buttons\config.png"));

            //Users
            //User
            //Картинка Назад
            BackBlockIMG.Source = new BitmapImage(new Uri(exepath + @"\Data\Images\Buttons\Backarrow.png"));
            //Картинка добавить
            CreateUserInUsersButtonImage.Source = new BitmapImage(new Uri(exepath + @"\Data\Images\Buttons\add.png"));
            //Картинка изменить
            EditUserInUserButtonImage.Source = new BitmapImage(new Uri(exepath + @"\Data\Images\Buttons\edit.png"));
            //Картинка удалить
            DeleteUserInUsersButtonTransformImage.Source = new BitmapImage(new Uri(exepath + @"\Data\Images\Buttons\delete.png"));
            //Картинка посмотреть
            ShowUserInUsersButtonImage.Source = new BitmapImage(new Uri(exepath + @"\Data\Images\Buttons\show.png"));

            //Position
            //Картинка добавить
            CreatePositionInUsersButtonImage.Source = new BitmapImage(new Uri(exepath + @"\Data\Images\Buttons\add.png"));
            //Картинка изменить
            EditPositionInUserButtonImage.Source = new BitmapImage(new Uri(exepath + @"\Data\Images\Buttons\edit.png"));
            //Картинка удалить
            DeletePositionInUserButtonTransformImage.Source = new BitmapImage(new Uri(exepath + @"\Data\Images\Buttons\delete.png"));
            //Картинка посмотреть
            ShowPositionInUsersButtonImage.Source = new BitmapImage(new Uri(exepath + @"\Data\Images\Buttons\show.png"));

            
        }
        #region Системные кнопки
        //Кнопка закрыть окно
        private void TextBlock_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }
        //Кнопка свернуть окно
        private void TextBlock_MouseDown_1(object sender, MouseButtonEventArgs e)
        {
            this.WindowState = System.Windows.WindowState.Minimized;
        }
        #endregion
       
        //Кнопка назад
        private void BackBlockIMG_MouseDown(object sender, MouseButtonEventArgs e)
        {
            grids[grids.Count - 1].Visibility = System.Windows.Visibility.Hidden;
            grids.RemoveAt(grids.Count - 1);
            grids[grids.Count - 1].Visibility = System.Windows.Visibility.Visible;
            
        }
        void OpenGrid(Grid grid)
        {
            grids[grids.Count - 1].Visibility = System.Windows.Visibility.Hidden;
            grid.Visibility = System.Windows.Visibility.Visible;
            grids.Add(grid);
        }
        // Кнопка Посмотреть пользователей
        private void ShowUsersButton_Click_1(object sender, RoutedEventArgs e)
        {
            OpenGrid(UsersGrid);
        }
        //Кнопка добавить пользователя в Пользователях
        private void CreateUserInUsersButton_Click(object sender, RoutedEventArgs e)
        {
            UsersFolder.AddUserWindow adduserwindow = new UsersFolder.AddUserWindow();
            adduserwindow.Owner = this;
            adduserwindow.ShowDialog();
        }

        private void ShowUserInUsersButton_Click(object sender, RoutedEventArgs e)
        {
            UsersFolder.ShowUser s = new UsersFolder.ShowUser();
            s.Owner = this;
            s.Show();
        }

        private void CreatePositionInUsersButton_Click(object sender, RoutedEventArgs e)
        {
            UsersFolder.AddPositionWindow z = new UsersFolder.AddPositionWindow();
            z.Show();
        }

       


    }
}
