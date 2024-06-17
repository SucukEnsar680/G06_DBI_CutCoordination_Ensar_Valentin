using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Ribbon;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace G06_DBI_CutCoordination
{
    /// <summary>
    /// Interaction logic for AddTermin.xaml
    /// </summary>
    public partial class AddTermin : Window
    {
        public TerminList Termins;
        public Termin EditingTermin { get; set; }
        public AddTermin(TerminList termins, bool Edit, Termin editingTermin)
        {
            InitializeComponent();
            this.Termins = termins;
            this.EditingTermin = editingTermin;
            Dauer.Foreground = Brushes.LightGray;
            Dauer.Text = "min";
            Uhrzeit.Text = "00:00";
            if (Edit == true && editingTermin != null)
            {
                Vorname.Text = editingTermin.Vorname;
                Nachname.Text = editingTermin.Nachname;
                Telefonnummer.Text = editingTermin.Telefonnummer;
                Uhrzeit.Text = editingTermin.Uhrzeit.ToString();
                Dauer.Text = editingTermin.Dauer.ToString();
                Dienstleistung.SelectedIndex = editingTermin.DienstId - 1;
                Datum.SelectedDate = editingTermin.Datum;
                addButton.Visibility = Visibility.Collapsed;
                editButton.Visibility = Visibility.Visible;

            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(Vorname.Text == "" || Nachname.Text == "" || Telefonnummer.Text == "" || Datum.SelectedDate == null || Uhrzeit.Text == "" || Dauer.Text == "" || Dienstleistung.SelectedIndex == -1)
            {
                MessageBox.Show("Bitte füllen Sie alle Felder aus!");
                return;
            }
            else
            {
				ComboBoxItem selectedItem = Dienstleistung.SelectedItem as ComboBoxItem;
				this.Termins.AddTermin(TerminManager.NewTermin(Vorname.Text, Nachname.Text, Telefonnummer.Text, DateTime.Parse(Datum.SelectedDate.Value.ToString("dd-MM-yyyy")), TimeSpan.Parse(Uhrzeit.Text), Convert.ToInt32(Dauer.Text), Convert.ToInt32(Dienstleistung.SelectedIndex) + 1, selectedItem.Content.ToString()));
                this.Close();
            }
            
        }

        private void editButton_Click(object sender, RoutedEventArgs e)
        {
            if (Vorname.Text == "" || Nachname.Text == "" || Telefonnummer.Text == "" || Datum.SelectedDate == null || Uhrzeit.Text == "" || Dauer.Text == "" || Dienstleistung.SelectedIndex == -1)
            {
                MessageBox.Show("Bitte füllen Sie alle Felder aus!");
                return;
            }
            else
            {
				ComboBoxItem selectedItem = Dienstleistung.SelectedItem as ComboBoxItem;
				Termins.UpdateTermin(EditingTermin, TerminManager.EditTermine(Vorname.Text, Nachname.Text, Telefonnummer.Text, DateTime.Parse(Datum.SelectedDate.Value.ToString("dd-MM-yyyy")), TimeSpan.Parse(Uhrzeit.Text), Convert.ToInt32(Dauer.Text), Convert.ToInt32(Dienstleistung.SelectedIndex) + 1, EditingTermin.Id, selectedItem.Content.ToString()));
                this.Close();
            }
            
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Dauer_GotFocus(object sender, RoutedEventArgs e)
        {
            if(Dauer.Text == "min")
            {
                Dauer.Text = "";
                Dauer.Foreground = Brushes.Black;
            }
        }

        private void Dauer_LostFocus(object sender, RoutedEventArgs e)
        {
            if (Dauer.Text == "")
            {
                Dauer.Text = "min";
                Dauer.Foreground = Brushes.LightGray;
            }
        }
    }
}
