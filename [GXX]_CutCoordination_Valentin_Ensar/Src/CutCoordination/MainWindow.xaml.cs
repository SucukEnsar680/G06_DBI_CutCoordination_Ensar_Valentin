using System.Globalization;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace G06_DBI_CutCoordination
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		#region variables
		private DateTime currentDate;
		private int[] smallWidths = new int[] { 70, 70, 80, 80, 110, 70 };
		public TerminList TerminList = new TerminList();
		#endregion

		#region constructors
		public MainWindow()
		{
			InitializeComponent();

			this.currentDate = DateTime.Today;
			terminsView.ItemsSource = this.TerminList.GetTodayTermins(this.currentDate);
			UmsatzText.Text = this.TerminList.GetUmsatz();
		}
		#endregion

		#region methods
		private void Window_MouseDown(object sender, MouseButtonEventArgs e)
		{
			try
			{
				if (e.ChangedButton == MouseButton.Left)
				{
					this.DragMove();
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.ToString());
			}

		}

		private void TitleMinimize_MouseDown(object sender, MouseButtonEventArgs e)
		{
			WindowState = WindowState.Minimized;
		}

		private void TitleMaximize_MouseDown(object sender, MouseButtonEventArgs e)
		{
			if (WindowState == WindowState.Maximized)
			{
				WindowState = WindowState.Normal;

				headLine.Margin = new Thickness(0, 0, 700, 0);
				headLine.FontSize = 18;
				addBtn.Width = 200;
				addBtn.Height = 100;
				editBtn.Width = 200;
				editBtn.Height = 100;
				removeBtn.Width = 200;
				removeBtn.Height = 100;

				for (int i = 0; i < smallWidths.Length; i++)
				{
					((GridView)terminsView.View).Columns[i].Width = smallWidths[i];
				}
			}
			else
			{
				WindowState = WindowState.Maximized;

				headLine.Margin = new Thickness(0, 10, 1600, 0);
				headLine.FontSize = 30;
				addBtn.Width = 300;
				addBtn.Height = 150;
				editBtn.Width = 300;
				editBtn.Height = 150;
				removeBtn.Width = 300;
				removeBtn.Height = 150;

				for (int i = 0; i < smallWidths.Length; i++)
				{
					((GridView)terminsView.View).Columns[i].Width = smallWidths[i] * 2;
				}
			}
		}

		private void TitleClose_MouseDown(object sender, MouseButtonEventArgs e)
		{
			this.Close();
		}

		private void AddBtn_Click(object sender, RoutedEventArgs e)
		{
			bool Edit = false;
			Termin EditingTermin = null;

			var addTermin = new AddTermin(this.TerminList, Edit, EditingTermin);
			addTermin.ShowDialog();

			this.TerminList = addTermin.Termins;
			this.TerminList.GetTodayTermins(this.currentDate);
            terminsView.ItemsSource = this.TerminList.GetTodayTermins(this.currentDate);
            UmsatzText.Text = this.TerminList.GetUmsatz();
        }

		private void EditBtn_Click(object sender, RoutedEventArgs e)
		{
			if (terminsView.SelectedItem != null)
			{
				bool Edit = true;
				Termin selectedTermin = (Termin)terminsView.SelectedItem;
				AddTermin addTermin = new AddTermin(this.TerminList, Edit, selectedTermin);
				addTermin.ShowDialog();

				this.TerminList = addTermin.Termins;
				terminsView.ItemsSource = this.TerminList.GetTodayTermins(this.currentDate);
                UmsatzText.Text = this.TerminList.GetUmsatz();
            }
		}

		private void RemoveBtn_Click(object sender, RoutedEventArgs e)
		{
			if (terminsView.SelectedItem != null)
			{
				Termin selectedTermin = (Termin)terminsView.SelectedItem;
				this.TerminList.RemoveTermin(selectedTermin);
				TerminManager.RemoveTermin(selectedTermin.Id);
				terminsView.ItemsSource = this.TerminList.GetTodayTermins(this.currentDate);
                UmsatzText.Text = this.TerminList.GetUmsatz();
            }
		}

		private void calendar_SelectedDatesChanged(object sender, SelectionChangedEventArgs e)
		{
			if (calendar.SelectedDate.HasValue)
			{
				this.currentDate = calendar.SelectedDate.Value;
				terminsView.ItemsSource = this.TerminList.GetTodayTermins(this.currentDate);
			}
		}
		#endregion
	}
}