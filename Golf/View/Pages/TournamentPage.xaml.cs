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
    /// Логика взаимодействия для TournamentPage.xaml
    /// </summary>
    public partial class TournamentPage : Page
    {
        TournamentTableAdapter tournamentTable = new TournamentTableAdapter();
        FieldsTableAdapter fieldsTable = new FieldsTableAdapter();
        public TournamentPage()
        {
            InitializeComponent();
            Grid.ItemsSource = tournamentTable.GetData();

            Fields_cb.ItemsSource = fieldsTable.GetData();
            Fields_cb.DisplayMemberPath = "Fields_name";
            Fields_cb.SelectedValuePath = "ID_Fields";
        }

        private void Insert_btn_Click(object sender, RoutedEventArgs e)
        {
            TimeSpan date;
            TimeSpan date1;

            if (Grid.ItemsSource == null || TimeStart_tp.Text == null || TimeEnd_tp.Text == null || String.IsNullOrWhiteSpace(TName_tb.Text) || String.IsNullOrWhiteSpace(Prize_tb.Text) )
            {
                MessageBox.Show("Имеются пустые поля или неверный формат даты");
            }
            else
            {
                if ((TimeSpan.TryParse(TimeStart_tp.Text, out date)) && (TimeSpan.TryParse(TimeEnd_tp.Text, out date1)))
                {
                    tournamentTable.InsertQuery(TName_tb.Text ,date.ToString(), date1.ToString(), Convert.ToInt32(Fields_cb.SelectedValue), Convert.ToInt32(Prize_tb.Text));
                    Grid.ItemsSource = tournamentTable.GetData();
                }

            }
        }

        private void Update_btn_Click(object sender, RoutedEventArgs e)
        {
            TimeSpan date;
            TimeSpan date1;

            if (Grid.ItemsSource == null || TimeStart_tp.Text == null || TimeEnd_tp.Text == null || String.IsNullOrWhiteSpace(TName_tb.Text) || String.IsNullOrWhiteSpace(Prize_tb.Text))
            {
                MessageBox.Show("Имеются пустые поля или неверный формат даты");
            }
            else
            {
                if ((TimeSpan.TryParse(TimeStart_tp.Text, out date)) && (TimeSpan.TryParse(TimeEnd_tp.Text, out date1)))
                {
                    object id = (Grid.SelectedItem as DataRowView).Row[0];
                    tournamentTable.UpdateQuery(TName_tb.Text, date.ToString(), date1.ToString(), Convert.ToInt32(Fields_cb.SelectedValue), Convert.ToInt32(Prize_tb.Text), Convert.ToInt32(id));
                    Grid.ItemsSource = tournamentTable.GetData();
                }

            }
        }

        private void Delete_btn_Click(object sender, RoutedEventArgs e)
        {
            object id = (Grid.SelectedItem as DataRowView).Row[0];
            tournamentTable.DeleteQuery(Convert.ToInt32(id));
            Grid.ItemsSource = tournamentTable.GetData();
        }
    }
}
