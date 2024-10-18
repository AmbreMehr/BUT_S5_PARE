using IHM_Model;
using Model;
using Network;
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

namespace IHM
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Module module;
        private SemesterVM semesterVM;
        private ISemesterNetwork semesterNetwork;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void OpenParametresPage(object sender, RoutedEventArgs e)
        {
            SettingsWindows settingsWindows = new SettingsWindows();
            settingsWindows.Show();
            this.Close();
        }

        private void LogOut(object sender, RoutedEventArgs e)
        {
            LoginWindow loginWindow = new LoginWindow();
            loginWindow.Show();
            this.Close();
        }

        private void AttributionModuleWindow(object sender, RoutedEventArgs e)
        {
            
        }

        private void AttributionProfilTypeWindow(object sender, RoutedEventArgs e)
        {

        }

        private void BilanAlertWindow(object sender, RoutedEventArgs e)
        {

        }

        private void PlacerModuleWindow(object sender, RoutedEventArgs e)
        {

        }

        private void EditModuleWindow(object sender, RoutedEventArgs e)
        {

        }
    }
}