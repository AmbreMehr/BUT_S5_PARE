using IHM_Model;
using Network;
using System.Collections.ObjectModel;
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
    /// <author>Clotilde MALO</author>
    public partial class MainWindow : Window
    {
        private SemestersVM semestersVM;
        private ModulesVM modulesVM;

        /// <summary>
        /// Constructeur de la classe MainWindow : initialise les composants de la fenêtre principale
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            this.semestersVM = new SemestersVM();
            this.modulesVM = new ModulesVM();
            MainViewModel mainViewModel = new MainViewModel(this.modulesVM, this.semestersVM);

            DataContext = mainViewModel;
        }

        /// <summary>
        /// Récupération des modules par semestre sélectionné
        /// </summary>
        public async void GetModulesBySemester()
        { 
            if (semestersVM.SelectedSemester != null)
            {
                // suppresssion des éléments qui ne sont pas ceux de base
                gridModules.Children.OfType<Border>().ToList().ForEach(child => gridModules.Children.Remove(child));
                await this.modulesVM.GetModuleBySemester(semestersVM.SelectedSemester);
                int decalage = 5;

                foreach (ModuleVM moduleVM in modulesVM.Modules)
                {
                    // prend en compte n° de colonnes pour les semaines
                    int gridColumnBegin = moduleVM.WeekBegin - 35;
                    int gridColumnEnd = moduleVM.WeekEnd - 35;

                    // Créé un rectangle et texte pour le module
                    Border moduleRectangle = new Border
                    {
                        Background = new SolidColorBrush(Colors.LightBlue),
                        BorderBrush = new SolidColorBrush(Colors.Black),
                        BorderThickness = new Thickness(1),
                        CornerRadius = new CornerRadius(5),
                        Height = 40,
                        Margin = new Thickness(35, decalage, 35, 0),
                        VerticalAlignment = VerticalAlignment.Top

                    };

                    TextBlock textBlock = new TextBlock
                    {
                        Text = moduleVM.Name,
                        HorizontalAlignment = HorizontalAlignment.Center,
                        VerticalAlignment = VerticalAlignment.Center,
                        FontSize = 16,
                        FontFamily = new FontFamily("OpenSauceOne")
                    };

                    moduleRectangle.Child = textBlock;

                    Grid.SetColumn(moduleRectangle, gridColumnBegin);
                    Grid.SetColumnSpan(moduleRectangle, gridColumnEnd - gridColumnBegin + 1);
                    Grid.SetRow(moduleRectangle, 1);

                    gridModules.Children.Add(moduleRectangle);
                    decalage += 60;
                }
            }
                    
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

        /// <summary>
        /// Evenement quand la selection change : appel GetModuleBySemester
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void changedSelection(object sender, SelectionChangedEventArgs e)
        {

            GetModulesBySemester();
        }
    }
}