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
		string currentMonth = "Jun";
		string currentYear = "2024";

		TerminList terminList = new TerminList();
        public MainWindow()
        {
            InitializeComponent();
            terminList.Visualize(terminsBox, info);
            LoadWeekTable();
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
            }
            else
            {
				WindowState = WindowState.Maximized;
			}
		}

        private void TitleClose_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            Window AddTermin = new AddTermin();
            AddTermin.ShowDialog();
            if (AddTermin.ShowDialog() == true)
            {
                AddTermin.Close();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(terminsBox.SelectedIndex != null)
            {
                string itemToRemove = terminsBox.SelectedIndex.ToString();
                terminList.RemoveItem(itemToRemove);
                terminsBox.Items.RemoveAt(terminsBox.SelectedIndex);
            }
        }

		private void Calendar_ButtonClicked(object sender, (string month, string year) e)
		{
			string currentMonth = e.month;
			string currentYear = e.year;
			MessageBox.Show($"Current Month: {currentMonth}, Current Year: {currentYear}");
		}

        private void LoadWeekTable()
        {
            Grid weekGrid = new Grid();
			weekGrid.Background = new SolidColorBrush(Colors.LightGray);

			for (int i = 0; i < 20; i++)
            {
                RowDefinition row = new RowDefinition();
                weekGrid.RowDefinitions.Add(row);
            }

            for(int j = 0; j < 7; j++)
            {
                ColumnDefinition column = new ColumnDefinition();
                weekGrid.ColumnDefinitions.Add(column);
            }

			for (int row = 0; row < 20; row++)
			{
				for (int col = 0; col < 7; col++)
				{
					Border cellBorder = new Border
					{
						BorderBrush = Brushes.Black, 
						BorderThickness = new Thickness(1), 
						Background = Brushes.White 
					};

					Grid.SetRow(cellBorder, row);
					Grid.SetColumn(cellBorder, col);
					weekGrid.Children.Add(cellBorder);
				}
			}

			TextBox helloTextBox = new TextBox
			{
				Text = "Hello",
				VerticalAlignment = VerticalAlignment.Center,
				HorizontalAlignment = HorizontalAlignment.Center
			};

			Grid.SetRow(helloTextBox, 1);
			Grid.SetColumn(helloTextBox, 1);
			weekGrid.Children.Add(helloTextBox);

			Grid.SetRow(weekGrid, 2);
            Grid.SetRowSpan(weekGrid, 3);
            Grid.SetColumn(weekGrid, 1);
            mainGrid.Children.Add(weekGrid);
		}
	}
}