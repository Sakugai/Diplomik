using System;
using System.Collections.Generic;
using System.Data;
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
using Golf.GolfDataSetTableAdapters;

namespace Golf.View.Pages
{
    /// <summary>
    /// Логика взаимодействия для StaffPage.xaml
    /// </summary>
    public partial class StaffPage : Page
    {
        StaffTableAdapter staffTable = new StaffTableAdapter();
        public StaffPage()
        {
            InitializeComponent();
            Grid.ItemsSource = staffTable.GetData();
        }

        private void Insert_btn_Click(object sender, RoutedEventArgs e)
        {
            if (Grid.ItemsSource == null || String.IsNullOrWhiteSpace(Surname_tb.Text) || String.IsNullOrWhiteSpace(Name_tb.Text) || String.IsNullOrWhiteSpace(MiddleName_tb.Text))
            {
                MessageBox.Show("Имеются пустые поля");
            }
            else
            {
                staffTable.InsertQuery(Surname_tb.Text, Name_tb.Text, MiddleName_tb.Text);
                Grid.ItemsSource = staffTable.GetData();
                Surname_tb.Clear();
                Name_tb.Clear();
                MiddleName_tb.Clear();
            }
        }

        private void Update_btn_Click(object sender, RoutedEventArgs e)
        {
            if (Grid.ItemsSource == null || String.IsNullOrWhiteSpace(Surname_tb.Text) || String.IsNullOrWhiteSpace(Name_tb.Text) || String.IsNullOrWhiteSpace(MiddleName_tb.Text))
            {
                MessageBox.Show("Имеются пустые поля");
            }
            else
            {
                object id = (Grid.SelectedItem as DataRowView).Row[0];
                staffTable.UpdateQuery(Surname_tb.Text, Name_tb.Text, MiddleName_tb.Text, Convert.ToInt32(id));
                Grid.ItemsSource = staffTable.GetData();
                Surname_tb.Clear();
                Name_tb.Clear();
                MiddleName_tb.Clear();
            }
        }

        private void Delete_btn_Click(object sender, RoutedEventArgs e)
        {
            if (Grid.ItemsSource == null)
            {
                MessageBox.Show("Имеются пустые поля");
            }
            else
            {
                object id = (Grid.SelectedItem as DataRowView).Row[0];
                staffTable.DeleteQuery( Convert.ToInt32(id));
                Grid.ItemsSource = staffTable.GetData();
            }
        } 
        
    }
}
