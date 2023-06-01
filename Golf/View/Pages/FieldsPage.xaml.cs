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
    /// Логика взаимодействия для FieldsPage.xaml
    /// </summary>
    public partial class FieldsPage : Page
    {
        FieldsTableAdapter fieldsTable = new FieldsTableAdapter();
        public FieldsPage()
        {
            InitializeComponent();
            Grid.ItemsSource = fieldsTable.GetData();
        }
        private void Insert_btn_Click(object sender, RoutedEventArgs e)
        {
            if (Grid.ItemsSource == null || String.IsNullOrWhiteSpace(Name_tb.Text) || String.IsNullOrWhiteSpace(Dicription_tb.Text))
            {
                MessageBox.Show("Имеются пустые поля");
            }
            else
            {
                fieldsTable.InsertQuery( Name_tb.Text, Dicription_tb.Text);
                Grid.ItemsSource = fieldsTable.GetData();
                Name_tb.Clear();
                Dicription_tb.Clear();
            }
        }

        private void Update_btn_Click(object sender, RoutedEventArgs e)
        {
            if (Grid.ItemsSource == null || String.IsNullOrWhiteSpace(Name_tb.Text) || String.IsNullOrWhiteSpace(Dicription_tb.Text))
            {
                MessageBox.Show("Имеются пустые поля");
            }
            else
            {
                object id = (Grid.SelectedItem as DataRowView).Row[0];
                fieldsTable.UpdateQuery( Name_tb.Text, Dicription_tb.Text, Convert.ToInt32(id));
                Grid.ItemsSource = fieldsTable.GetData();
                Name_tb.Clear();
                Dicription_tb.Clear();
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
                fieldsTable.DeleteQuery(Convert.ToInt32(id));
                Grid.ItemsSource = fieldsTable.GetData();
            }
        }
    }
}
