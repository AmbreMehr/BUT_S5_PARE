using IHM_Model;
using Model;
using Network;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Shapes;

namespace IHM
{
    /// <summary>
    /// Logique d'interaction pour PlaceModuleWindow.xaml
    /// </summary>
    public partial class PlaceModuleWindow : UserControl
    {
        private SemestersVM semestersVM;
        private ModulesVM modulesVM;

        public event EventHandler ValidationCompleted = delegate { };
        public event EventHandler Canceled = delegate { };

        /// <summary>
        /// Constructeur du component, affiche les semestres à placer et met à jour la liste des modules
        /// </summary>
        /// <param name="semestersVM"></param>
        /// <param name="modulesVM"></param>
        public PlaceModuleWindow(SemestersVM semestersVM, ModulesVM modulesVM)
        {
            InitializeComponent();
            
            this.semestersVM = semestersVM;
            this.modulesVM = modulesVM;
            
            
            DataContext = new MainViewModel(this.modulesVM, this.semestersVM);

            Task task = UpdateModulesList();
        }

        /// <summary>
        /// Méthode permettant de mettre à jour les différents modules dans l'affichage
        /// </summary>
        /// <returns></returns>
        private async Task UpdateModulesList()
        {
            SemesterVM? selectedSemester = semestersVM.SelectedSemester;
            if (selectedSemester != null)
            {
                await this.modulesVM.GetModuleBySemester(selectedSemester);
                ModulesList.ItemsSource = this.modulesVM.Modules;
            }
            else
            {
                MessageBox.Show((string)System.Windows.Application.Current.FindResource("SelectionSemestre"), (string)System.Windows.Application.Current.FindResource("Erreur"), MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
        /// <summary>
        /// Logique du bouton Valider
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void ClickBtnSave(object sender, RoutedEventArgs e)
        {
            try
            {
                await modulesVM.UpdateModules(); // Appel à la méthode qui met à jour les modules
                MessageBox.Show(
                     (string)System.Windows.Application.Current.FindResource("MiseAJourModules"),
                    (string)System.Windows.Application.Current.FindResource("Succes"),
                    MessageBoxButton.OK,
                    MessageBoxImage.Information);

                ValidationCompleted?.Invoke(this, EventArgs.Empty); // Notifie la fin de la validation
            }
            catch (Exception ex)
            {
                GestionException(ex, "ErreurDeValidation");
            }
        }

        /// <summary>
        /// Permet d'affiche une pop up pour l'affichage des exceptions
        /// </summary>
        /// <param name="ex">exception</param>
        /// <param name="RessourceName">nom de la ressource pour titre</param>
        private void GestionException(Exception ex, string RessourceName)
        {
            MessageBox.Show($"{ex.Message}",
                            (string)System.Windows.Application.Current.FindResource(RessourceName),
                            MessageBoxButton.OK,
                            MessageBoxImage.Warning);
        }

        /// <summary>
        /// Logique du bouton Annuler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ClickBtnQuit(object sender, RoutedEventArgs e)
        {
            Canceled?.Invoke(this, EventArgs.Empty);
            this.Visibility = Visibility.Collapsed;
        }
    }
}
  