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
        private int[] smallWidths = new int[] { 70, 70, 80, 80, 110, 70 };
		TerminList terminList = new TerminList();
        private DateTime currentDate;

        public MainWindow()
        {
            InitializeComponent();

            currentDate = DateTime.Today;
            terminsView.ItemsSource = terminList.GetTodayTermins(currentDate);  
        }

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

                headLine.Margin = new Thickness(0, 0, 600, 0);
                addBtn.Margin = new Thickness(55, 45, 55, 45);
                removeBtn.Margin = new Thickness(55, 5, 55, 85);

				for (int i = 0; i < smallWidths.Length; i++)
                {
					((GridView)terminsView.View).Columns[i].Width = smallWidths[i];
				}
			}
            else
            {
				WindowState = WindowState.Maximized;

				headLine.Margin = new Thickness(0, 0, 1500, 0);
				addBtn.Margin = new Thickness(115, 95, 115, 95);
                removeBtn.Margin = new Thickness(115, 15, 115, 175);

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
            
            var addTermin = new AddTermin(terminList);
            addTermin.ShowDialog();
            terminList = addTermin.Termins;
            terminList.GetTodayTermins(this.currentDate);

            
        }

		private void RemoveBtn_Click(object sender, RoutedEventArgs e)
		{
			if (terminsView.SelectedItem != null)
			{
				Termin selectedTermin = (Termin)terminsView.SelectedItem;
				terminList.RemoveItem(selectedTermin);
				terminsView.ItemsSource = terminList.GetTodayTermins(this.currentDate);
			}
		}

		private void calendar_SelectedDatesChanged(object sender, SelectionChangedEventArgs e)
		{
			if (calendar.SelectedDate.HasValue)
			{
				this.currentDate = calendar.SelectedDate.Value;

                terminsView.ItemsSource = terminList.GetTodayTermins(this.currentDate);
			}
		}
    }
}