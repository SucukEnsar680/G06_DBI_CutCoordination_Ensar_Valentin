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
        public AddTermin(TerminList termins)
        {
            InitializeComponent();
            this.Termins = termins;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Termins.AddTermin(TerminManager.NewTermin(Vorname.Text, Nachname.Text, Telefonnummer.Text, DateTime.Parse(Datum.SelectedDate.Value.ToString("dd-MM-yyyy")), TimeSpan.Parse(Uhrzeit.Text), Convert.ToInt32(Dauer.Text), Convert.ToInt32(Dienstleistung.SelectedIndex) + 1));
			
		}
    }
}
