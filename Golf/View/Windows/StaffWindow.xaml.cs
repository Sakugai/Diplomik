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
    /// Логика взаимодействия для StaffWindow.xaml
    /// </summary>
    public partial class StaffWindow : Window
    {
        public StaffWindow()
        {
            InitializeComponent();
        }

        private void Fields_btn_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(new Pages.FieldsPage());
        }

        private void Client_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(new Pages.ClientPage());
        }

        private void Tournament_btn_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(new Pages.TournamentPage());
        }

        private void Avtoriz_btn_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            main.Show();
            Close();
        }
    }
}
