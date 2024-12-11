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
                IEnumerable<ModuleVM> modulesCopy = modulesVM.ModulesROnly;

                int decalage = 5;

                foreach (ModuleVM moduleVM in modulesCopy)
                {

                    if (moduleVM.WeekBegin > semestersVM.SelectedSemester.WeekBegin && moduleVM.WeekEnd < semestersVM.SelectedSemester.WeekBegin && moduleVM.WeekBegin <= moduleVM.WeekEnd)
                    {
                        MessageBox.Show(
                            $"{moduleVM.Name} : " + (string)System.Windows.Application.Current.FindResource("MessageTitleModulePlacementInvalide"),
                            (string)System.Windows.Application.Current.FindResource("MessageTitleModulePlacementInvalide"),
                            MessageBoxButton.OK,
                            MessageBoxImage.Warning);
                        continue;
                    }
                    AddModuleToGrid(moduleVM, semestersVM.SelectedSemester.Name, decalage);
                    decalage += 60;
                }
            }
        }

        /// <summary>
        /// Ajoute un module au grid avec les propriétés appropriées
        /// </summary>
        private void AddModuleToGrid(ModuleVM module, string semesterName, int decalage)
        {
            var moduleRectangle = new Border
            {
                Background = new SolidColorBrush(Colors.LightBlue),
                BorderBrush = new SolidColorBrush(Colors.Black),
                BorderThickness = new Thickness(1),
                CornerRadius = new CornerRadius(5),
                Height = 40,
                Margin = new Thickness(35, decalage, 35, 0),
                VerticalAlignment = VerticalAlignment.Top
            };

            var textBlock = new TextBlock
            {
                Text = module.Name,
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
                FontSize = 16,
                FontFamily = new FontFamily("OpenSauceOne")
            };

            moduleRectangle.Child = textBlock;

            Grid.SetColumn(moduleRectangle, module.WeekBegin - module.Model.Semester.SemesterWeekBegin +1);
            Grid.SetColumnSpan(moduleRectangle, module.WeekEnd - module.WeekBegin + 1);
            Grid.SetRow(moduleRectangle, 2);

            gridModules.Children.Add(moduleRectangle);
            ShowStudentHours();
        }

        private async void ShowStudentHours()
        {
            SemesterVM? semester = semestersVM.SelectedSemester;
            if (semester != null)
            {
                float acceptableStudentsHours = 35;
                gridModules.Children.OfType<Rectangle>().ToList().ForEach(child => gridModules.Children.Remove(child));
                Border placeHolder = new Border
                {
                    BorderBrush = new SolidColorBrush(Colors.Black),
                    BorderThickness = new Thickness(1)
                };
                Grid.SetRow(placeHolder, 0);
                Grid.SetColumn(placeHolder, 1);
                Grid.SetColumnSpan(placeHolder, semester.NbWeek);
                gridModules.Children.Add(placeHolder);

                Dictionary<int, float> hoursPerWeek = await semester.GetHoursPerWeek();
                foreach (int week in hoursPerWeek.Keys)
                {
                    Rectangle jauge = new Rectangle
                    {
                        Fill = new SolidColorBrush(Colors.Black),
                        Margin = new Thickness(20, 0, 20, 0),
                        Height = hoursPerWeek[week] / acceptableStudentsHours * gridModules.RowDefinitions.First().Height.Value,
                        VerticalAlignment = VerticalAlignment.Bottom
                    };
                    Grid.SetRow(jauge, 0);
                    Grid.SetColumn(jauge, week - semester.WeekBegin + 1);
                    gridModules.Children.Add(jauge);
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
            BilanDesAlertesWindow bilan = new BilanDesAlertesWindow();
            bilan.Show();
            this.Close();
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

        /// <summary>
        /// Met à jour la grid de l'IHM pour le placement des modules
        /// </summary>
        /// <param name="semestreActuel"></param>
        private void UpdateWeekSemester(SemesterVM semestreActuel)
        {
            for (int i = 0; i < (semestreActuel.NbWeek); i++)
            {
                Label label = (Label)FindName($"labelSemaine{i + 1}");
                if (label != null)
                {
                    label.Content = (semestreActuel.WeekBegin + i).ToString();
                }
            }
        }
    }
}