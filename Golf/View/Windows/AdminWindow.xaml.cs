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

namespace Golf.View.Windows
{
    /// <summary>
    /// Логика взаимодействия для AdminWindow.xaml
    /// </summary>
    public partial class AdminWindow : Window
    {
        public AdminWindow()
        {
            InitializeComponent();
        }

        private void Staff_btn_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(new Pages.StaffPage());
        }

        private void Booking_btn_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(new Pages.BookingPage());
        }

        private void Avtoriz_btn_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main  = new MainWindow();
            main.Show();
            Close();
        }
    }
}
