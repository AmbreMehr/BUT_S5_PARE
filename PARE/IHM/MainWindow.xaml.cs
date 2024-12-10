using IHM_Model;
using Model;
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
                UpdateWeekSemester(semestersVM.SelectedSemester);

                // Suppression des éléments qui ne sont pas ceux de base
                gridModules.Children.OfType<Border>().ToList().ForEach(child => gridModules.Children.Remove(child));
                await this.modulesVM.GetModuleBySemester(semestersVM.SelectedSemester);

                // Crée une copie immuable des modules pour éviter des modifications pendant l'itération
                var modulesCopy = modulesVM.Modules.ToList();

                int decalage = 5;

                foreach (ModuleVM moduleVM in modulesCopy)
                {
                    // Valider les indices de colonnes calculés
                    if (moduleVM.WeekBegin < 0 ||moduleVM.WeekEnd < 0 || moduleVM.WeekBegin > moduleVM.WeekEnd)
                    {
                        MessageBox.Show(
                            $"Le module '{moduleVM.Name}' a des indices de colonne invalides : Début={moduleVM.WeekBegin}, Fin={moduleVM.WeekEnd}.",
                            "Erreur de placement",
                            MessageBoxButton.OK,
                            MessageBoxImage.Warning);
                        continue; // Ignore ce module et passe au suivant
                    }

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

                    Grid.SetColumn(moduleRectangle, moduleVM.WeekBegin);
                    Grid.SetColumnSpan(moduleRectangle, moduleVM.WeekEnd - moduleVM.WeekBegin + 1);
                    Grid.SetRow(moduleRectangle, 1);

                    gridModules.Children.Add(moduleRectangle);
                    decalage += 60;
                }
            }
        }


        /// <summary>
        /// Ouvre la page des paramètres
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OpenParametresPage(object sender, RoutedEventArgs e)
        {
            SettingsWindows settingsWindows = new SettingsWindows();
            settingsWindows.ShowDialog();
            this.Close();
        }

        /// <summary>
        /// Permet de se déconnecter de l'application et ramène sur la page de login
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LogOut(object sender, RoutedEventArgs e)
        {
            LoginWindow loginWindow = new LoginWindow();
            loginWindow.Show();
            this.Close();
        }

        /// <summary>
        /// Ouvre la page Attribution des modules
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AttributionModuleWindow(object sender, RoutedEventArgs e)
        {
            ModuleSupervisorsWindow moduleSupervisorsWindow = new ModuleSupervisorsWindow(semestersVM);
            moduleSupervisorsWindow.Show();
            this.Close();
        }

        /// <summary>
        /// Ouvrira la page Attribution profil type
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AttributionProfilTypeWindow(object sender, RoutedEventArgs e)
        {

        }

        /// <summary>
        /// Ouvrira la page Bilan des alertes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BilanAlertWindow(object sender, RoutedEventArgs e)
        {

        }

        /// <summary>
        /// Affiche le component qui permet de placer / modifier temporellement les modules
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PlacerModuleWindow(object sender, RoutedEventArgs e)
        {
            PlaceModuleWindow placeModuleWindow = new PlaceModuleWindow(semestersVM, modulesVM);

            ToggleBottomButtonsVisibility(false);


            Grid.SetRow(placeModuleWindow, 2);
            grid.Children.Add(placeModuleWindow);

            placeModuleWindow.ValidationCompleted += (s, args) =>
            {
                GetModulesBySemester();
            };
            placeModuleWindow.Canceled += (s, args) =>
            {
                grid.Children.Remove(placeModuleWindow); 
                ToggleBottomButtonsVisibility(true); 
            };
        }

        /// <summary>
        /// Evenement pour ouvrir la fenêtre d'édition de module
        /// </summary>
        /// <author>Clotilde MALO</author>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EditModuleWindow(object sender, RoutedEventArgs e)
        {
            new EditModuleWindow(semestersVM).Show();
            this.Close();
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

        /// <summary>
        /// Méthode permettant de modifier la visibilité des boutons sur l'écran d'accueil
        /// </summary>
        /// <param name="IsVisible"></param>
        private void ToggleBottomButtonsVisibility(bool IsVisible)
        {
            BtnAttributionModule.Visibility = IsVisible ? Visibility.Visible : Visibility.Collapsed;
            BtnAttributionProfilType.Visibility = IsVisible ? Visibility.Visible : Visibility.Collapsed;
            BtnBilanAlertes.Visibility = IsVisible ? Visibility.Visible : Visibility.Collapsed;
            BtnEditerModules.Visibility = IsVisible ? Visibility.Visible : Visibility.Collapsed;
            BtnPlacerModules.Visibility = IsVisible ? Visibility.Visible : Visibility.Collapsed;
        }

        private void UpdateWeekSemester(SemesterVM semestreActuel)
        {
            labelSemaine1.Content = semestreActuel.WeekBegin.ToString();
            labelSemaine2.Content = (semestreActuel.WeekBegin+1).ToString();
            labelSemaine3.Content = (semestreActuel.WeekBegin+2).ToString();
            labelSemaine4.Content = (semestreActuel.WeekBegin+3).ToString();
            labelSemaine5.Content = (semestreActuel.WeekBegin+4).ToString();
            labelSemaine6.Content = (semestreActuel.WeekBegin+5).ToString();
            labelSemaine7.Content = (semestreActuel.WeekBegin+6).ToString();
            labelSemaine8.Content = (semestreActuel.WeekBegin+7).ToString();
            labelSemaine9.Content = (semestreActuel.WeekBegin+8).ToString();
            labelSemaine10.Content = (semestreActuel.WeekBegin+9).ToString();
            labelSemaine11.Content = (semestreActuel.WeekBegin+10).ToString();
            labelSemaine12.Content = (semestreActuel.WeekBegin+11).ToString();
            labelSemaine13.Content = (semestreActuel.WeekBegin+12).ToString();
        }
    }
}