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

namespace G06_DBI_CutCoordination
{
    /// <summary>
    /// Interaction logic for AddTermin.xaml
    /// </summary>
    public partial class AddTermin : Window
    {
        public AddTermin()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DateTime datum = DateTime.Parse(Datum.Text);
            TimeSpan uhrzeit = TimeSpan.Parse(Uhrzeit.Text);
            TerminManager.NewTermin(Vorname.Text, Nachname.Text, Telefonnummer.Text, datum, uhrzeit, Convert.ToInt32(Dauer.Text), Convert.ToInt32(Dienstleistung.SelectedIndex) + 1);
        }
    }
}
