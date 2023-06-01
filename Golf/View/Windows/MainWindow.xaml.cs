using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
using Golf.GolfDataSetTableAdapters;

namespace Golf.View.Windows
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        AutorizationTableAdapter autorizationTable = new AutorizationTableAdapter();
        
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Avtoriz_Click(object sender, RoutedEventArgs e)
        {
            var avtoriz = autorizationTable.GetData().Rows;
            Boolean proverka = true;
            if (String.IsNullOrWhiteSpace(Login.Text) || String.IsNullOrWhiteSpace(Password.Password))
                MessageBox.Show("Имеются пустые поля");
            else
            {
                for (int i = 0; i < avtoriz.Count; i++)
                {
                    if (avtoriz[i][1].ToString() == Login.Text && avtoriz[i][2].ToString() == Password.Password)
                    {
                        int role = (int)avtoriz[i][3];
                        switch (role)
                        {
                            case 1:
                                StaffWindow wind = new StaffWindow();
                                wind.Show();
                                Close();
                                proverka = false;
                                break;
                            case 2:
                                AdminWindow winds = new AdminWindow();
                                winds.Show();
                                Close();
                                proverka = false;
                                break;
                            case 3:
                                ClientWindow window = new ClientWindow();
                                window.Show();
                                Close();
                                proverka = false;
                                break;
                        }
                    }
                }
                if (proverka != false)
                {
                    MessageBox.Show("Неверен логин или пароль");
                }
            }
        }
    }
}
