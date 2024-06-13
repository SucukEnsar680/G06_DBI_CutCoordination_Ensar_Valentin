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
        public MainWindow()
        {
            InitializeComponent();
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
    }
}