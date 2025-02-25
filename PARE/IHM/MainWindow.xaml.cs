﻿using IHM_Model;
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

            this.semestersVM.ErrorOccurred += HandleErrorOccurred;

            DataContext = mainViewModel;
        }

        #region Création IHM
        /// <summary>
        /// Récupération des modules par semestre sélectionné
        /// </summary>
        public async void GetModulesBySemester()
        {
            if (semestersVM.SelectedSemester != null)
            {
                // Suppression des éléments qui ne sont pas ceux de base
                DeleteTypeFromGrid<Border>();
                await this.modulesVM.GetModuleBySemester(semestersVM.SelectedSemester);

                // Crée une copie immuable des modules pour éviter des modifications pendant l'itération
                IEnumerable<ModuleVM> modulesCopy = modulesVM.ModulesROnly;
                InitializeSemesterColumns();
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

                ShowStudentHours();
                gridModules.Children.OfType<Line>().ToList().ForEach(line =>
                {
                    line.Y2 = Math.Max(line.Y2, decalage);
                });
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
                ToolTip = module.Name,
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
                FontSize = 16,
                FontFamily = new FontFamily("OpenSauceOne")
            };

            moduleRectangle.Child = textBlock;

            Grid.SetColumn(moduleRectangle, module.WeekBegin - module.Model.Semester.SemesterWeekBegin + 1);
            Grid.SetColumnSpan(moduleRectangle, module.WeekEnd - module.WeekBegin + 1);
            Grid.SetRow(moduleRectangle, 2);

            gridModules.Children.Add(moduleRectangle);
        }

        /// <summary>
        /// Affiche la charge des étudiants 
        /// </summary>
        private async void ShowStudentHours()
        {
            SemesterVM? semester = semestersVM.SelectedSemester;
            if (semester != null)
            {



                float acceptableStudentsHoursMin = 30;
                float acceptableStudentsHoursMax = 35;
                double rectangleMaxHeight = gridModules.RowDefinitions.First().Height.Value;
                DeleteTypeFromGrid<Rectangle>();
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
                    float hours = hoursPerWeek[week];
                    Rectangle jauge = new Rectangle
                    {
                        Fill = new SolidColorBrush(Colors.Black),
                        Margin = new Thickness(20, 0, 20, placeHolder.BorderThickness.Bottom),
                        Height = hoursPerWeek[week] / acceptableStudentsHoursMax * rectangleMaxHeight,
                        VerticalAlignment = VerticalAlignment.Bottom
                    };
                    if (hours > acceptableStudentsHoursMax)
                    {
                        jauge.Fill = (SolidColorBrush)System.Windows.Application.Current.FindResource("StudentHoursOver");
                        jauge.Height = rectangleMaxHeight;
                    }
                    else if (hours < acceptableStudentsHoursMin)
                    {
                        jauge.Fill = (SolidColorBrush)System.Windows.Application.Current.FindResource("StudentHoursUnder");
                    }
                    Grid.SetRow(jauge, 0);
                    Grid.SetColumn(jauge, week - semester.WeekBegin + 1);
                    gridModules.Children.Add(jauge);
                }
            }
        }

        /// <summary>
        /// Créer les colonnes pour afficher les semaines du semestre
        /// </summary>
        private void InitializeSemesterColumns()
        {
            SemesterVM? semester = semestersVM.SelectedSemester;
            if (semester != null)
            {
                // Suppression de l'existant
                DeleteTypeFromGrid<Line>();
                DeleteTypeFromGrid<Label>();
                var defaultColCreator = () => { return new ColumnDefinition(); };
                var lineCreator = () => { return new Line { Style = this.FindResource("DashedLineStyle") as Style }; };
                var labelCreator = () => { return new Label { HorizontalAlignment = HorizontalAlignment.Center, VerticalAlignment = VerticalAlignment.Top, FontFamily = this.FindResource("OpenSauceOne") as FontFamily, FontSize = 30 }; };
                gridModules.ColumnDefinitions.Clear();
                gridModules.ColumnDefinitions.Add(defaultColCreator());
                gridModules.ColumnDefinitions.Add(defaultColCreator());
                for (int i = semester.WeekBegin; i <= semester.WeekEnd; i++)
                {
                    gridModules.ColumnDefinitions.Add(defaultColCreator());
                    Line line = lineCreator();
                    line.Y2 = gridModules.RowDefinitions.Last().ActualHeight;
                    Grid.SetRow(line, 2);
                    Grid.SetColumn(line, i - semester.WeekBegin + 1);
                    gridModules.Children.Add(line);
                    Label label = labelCreator();
                    label.Content = i;
                    Grid.SetRow(label, 1);
                    Grid.SetColumn(label, i - semester.WeekBegin + 1);
                    gridModules.Children.Add(label);
                }
            }
        }

        /// <summary>
        /// Supprime les éléments d'un type particulier de l'IHM
        /// </summary>
        /// <typeparam name="T">UIElement à supprimer</typeparam>
        private void DeleteTypeFromGrid<T>()
        {
            gridModules.Children.OfType<T>().ToList().ForEach(child => gridModules.Children.Remove(child as UIElement));
        }
        #endregion Création IHM

        #region Logique IHM
        /// <summary>
        /// Ouvre la page des paramètres
        /// </summary>
        private void OpenParametresPage(object sender, RoutedEventArgs e)
        {
            SettingsWindows settingsWindows = new SettingsWindows();
            settingsWindows.ShowDialog();
        }

        /// <summary>
        /// Permet de se déconnecter de l'application et ramène sur la page de login
        /// </summary>
        private void LogOut(object sender, RoutedEventArgs e)
        {
            LoginWindow loginWindow = new LoginWindow();
            loginWindow.Show();
            this.Close();
        }

        /// <summary>
        /// Ouvre la page Attribution des modules
        /// </summary>
        private void AttributionModuleWindow(object sender, RoutedEventArgs e)
        {
            ModuleSupervisorsWindow moduleSupervisorsWindow = new ModuleSupervisorsWindow(semestersVM);
            moduleSupervisorsWindow.Show();
        }

        /// <summary>
        /// Ouvre la page Bilan des alertes
        /// </summary>
        private void BilanAlertWindow(object sender, RoutedEventArgs e)
        {
            BilanDesAlertesWindow bilan = new BilanDesAlertesWindow(semestersVM);
            bilan.Show();
        }

        /// <summary>
        /// Evenement pour ouvrir la fenêtre d'édition de module
        /// </summary>
        /// <author>Clotilde MALO</author>
        private void EditModuleWindow(object sender, RoutedEventArgs e)
        {
            new EditModuleWindow(semestersVM).Show();
        }

        /// <summary>
        /// Evenement quand la selection change : appel GetModuleBySemester
        /// </summary>
        private void changedSelection(object sender, SelectionChangedEventArgs e)
        {
            GetModulesBySemester();
        }

        /// <summary>
        /// Message Box apparaissant quand l'API ne se lance pas correctement 
        /// </summary>
        /// <param name="errorMessage">Message d'erreur à afficher</param>
        private void HandleErrorOccurred(object sender, string errorMessage)
        {
            MessageBox.Show(
                errorMessage,
                (string)System.Windows.Application.Current.FindResource("Erreur"),
                MessageBoxButton.OK,
                MessageBoxImage.Error
            );
        }
        #endregion Logique IHM

        #region Placement Modules
        /// <summary>
        /// Affiche le component qui permet de placer / modifier temporellement les modules
        /// </summary>
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
            infoSemester.Visibility = IsVisible ? Visibility.Collapsed : Visibility.Visible;
        }
        #endregion Placement Modules
    }
}