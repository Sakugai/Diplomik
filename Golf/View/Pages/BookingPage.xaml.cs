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
    /// Логика взаимодействия для BookingPage.xaml
    /// </summary>
    public partial class BookingPage : Page
    {
        BookingTableAdapter bookingTable = new BookingTableAdapter();
        StaffTableAdapter staffTable = new StaffTableAdapter();
        InventoryTableAdapter inventoryTable = new InventoryTableAdapter();
        ClientTableAdapter clientTable = new ClientTableAdapter();
        FieldsTableAdapter fieldsTable = new FieldsTableAdapter();
        public BookingPage()
        {
            InitializeComponent();
            Grid.ItemsSource = bookingTable.GetData();

            Client_cb.ItemsSource = clientTable.GetData();
            Client_cb.DisplayMemberPath = "Surnames";
            Client_cb.SelectedValuePath = "ID_Client";

            Field_cb.ItemsSource = fieldsTable.GetData();
            Field_cb.DisplayMemberPath = "Fields_name";
            Field_cb.SelectedValuePath = "ID_Fields";

            Inventary_cb.ItemsSource = inventoryTable.GetData();
            Inventary_cb.DisplayMemberPath = "Inventory_name";
            Inventary_cb.SelectedValuePath = "ID_Inventory";

            Staff_cb.ItemsSource = staffTable.GetData();
            Staff_cb.DisplayMemberPath = "Surnames";
            Staff_cb.SelectedValuePath = "ID_Staff";
        }

        private void Insert_btn_Click(object sender, RoutedEventArgs e)
        {
            TimeSpan date;
            TimeSpan date1;

            if (Grid.ItemsSource == null || TimeStart_tp.Text == null || TimeEnd_tp.Text == null)
            {
                MessageBox.Show("Имеются пустые поля или неверный формат даты");
            }
            else
            {
                if ((TimeSpan.TryParse(TimeStart_tp.Text, out date)) && (TimeSpan.TryParse(TimeEnd_tp.Text, out date1)))
                {
                    bookingTable.InsertQuery(date.ToString(), date1.ToString(), Convert.ToInt32(Client_cb.SelectedValue), Convert.ToInt32(Field_cb.SelectedValue), Convert.ToInt32(Inventary_cb.SelectedValue), Convert.ToInt32(Staff_cb.SelectedValue));
                    Grid.ItemsSource = bookingTable.GetData();
                }

            }
        }

        private void Update_btn_Click(object sender, RoutedEventArgs e)
        {
            TimeSpan date;
            TimeSpan date1;

            if (Grid.ItemsSource == null || TimeStart_tp.Text == null || TimeEnd_tp.Text == null)
            {
                MessageBox.Show("Имеются пустые поля или неверный формат даты");
            }
            else
            {
                if ((TimeSpan.TryParse(TimeStart_tp.Text, out date)) && (TimeSpan.TryParse(TimeEnd_tp.Text, out date1)))
                {
                    object id = (Grid.SelectedItem as DataRowView).Row[0];
                    bookingTable.UpdateQuery(date.ToString(), date1.ToString(), Convert.ToInt32(Client_cb.SelectedValue), Convert.ToInt32(Field_cb.SelectedValue), Convert.ToInt32(Inventary_cb.SelectedValue), Convert.ToInt32(Staff_cb.SelectedValue), Convert.ToInt32(id));
                    Grid.ItemsSource = bookingTable.GetData();
                }

            }
        }

        private void Delete_btn_Click(object sender, RoutedEventArgs e)
        {
            object id = (Grid.SelectedItem as DataRowView).Row[0];
            bookingTable.DeleteQuery(Convert.ToInt32(id));
            Grid.ItemsSource = bookingTable.GetData();
        }
    }
}
