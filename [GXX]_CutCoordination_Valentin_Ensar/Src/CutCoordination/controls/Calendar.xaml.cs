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
using System.Windows.Navigation;
using System.Windows.Shapes;
using static System.Net.Mime.MediaTypeNames;

namespace G06_DBI_CutCoordination.controls
{
	/// <summary>
	/// Interaktionslogik für Calendar.xaml
	/// </summary>
	public partial class Calendar : UserControl
	{
		public event EventHandler<(string month, string year)> ButtonClicked;

		private string currentYear = "2024";
		private string currentMonth = "Jun";
		public Calendar()
		{
			InitializeComponent();
			infoBox.Text = currentMonth + "  " + currentYear;
		}

		private void Button_Click(object sender, RoutedEventArgs e)
		{
			Button clickedButton = sender as Button;
			currentMonth = clickedButton.Content.ToString();
			infoBox.Text = currentMonth + "  " + currentYear;
			ButtonClicked?.Invoke(this, (currentMonth, currentYear));
		}

		private void ArrowLeft_Click(object sender, MouseButtonEventArgs e)
		{

			currentYear = (int.Parse(currentYear) - 1).ToString();
			infoBox.Text = currentMonth + "  " + currentYear;
		}

		private void ArrowRight_Click(object sender, MouseButtonEventArgs e)
		{
			currentYear = (int.Parse(currentYear) + 1).ToString();
			infoBox.Text = currentMonth + "  " + currentYear;
		}
	}
}