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
    /// Логика взаимодействия для ClientPage.xaml
    /// </summary>
    public partial class ClientPage : Page
    {
        ClientTableAdapter clientTable = new ClientTableAdapter();
        MembershipTableAdapter membershipTable = new MembershipTableAdapter();
        public ClientPage()
        {
            InitializeComponent();
            Grid.ItemsSource = clientTable.GetData();

            Membership_cb.ItemsSource = membershipTable.GetData();
            Membership_cb.DisplayMemberPath = "Membership_name";
            Membership_cb.SelectedValuePath = "ID_Membership";
        }

        private void Insert_btn_Click(object sender, RoutedEventArgs e)
        {
            if (Grid.ItemsSource == null || String.IsNullOrWhiteSpace(Surname_tb.Text) || String.IsNullOrWhiteSpace(Name_tb.Text) || String.IsNullOrWhiteSpace(MiddleName_tb.Text))
            {
                MessageBox.Show("Имеются пустые поля");
            }
            else
            {
                clientTable.InsertQuery(Surname_tb.Text, Name_tb.Text, MiddleName_tb.Text, Convert.ToInt32(Membership_cb.SelectedValue));
                Grid.ItemsSource = clientTable.GetData();
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
                clientTable.UpdateQuery(Surname_tb.Text, Name_tb.Text, MiddleName_tb.Text, Convert.ToInt32(Membership_cb.SelectedValue), Convert.ToInt32(id));
                Grid.ItemsSource = clientTable.GetData();
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
                clientTable.DeleteQuery(Convert.ToInt32(id));
                Grid.ItemsSource = clientTable.GetData();
            }
        }
    }
}
