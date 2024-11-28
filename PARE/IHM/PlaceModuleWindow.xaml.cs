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

        public event EventHandler ValidationCompleted;
        public event EventHandler Canceled;


        public PlaceModuleWindow(SemestersVM semestersVM, ModulesVM modulesVM)
        {
            InitializeComponent();
            
            this.semestersVM = semestersVM;
            this.modulesVM = modulesVM;
            
            
            DataContext = new MainViewModel(this.modulesVM, this.semestersVM);

            Task task = UpdateModulesList();
        }


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

        private async void ClickBtnValider(object sender, RoutedEventArgs e)
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
                this.Visibility = Visibility.Collapsed;
            }
            catch (ArgumentOutOfRangeException ex)
            {
                // Gestion des erreurs liées aux semaines hors limites
                MessageBox.Show(
                    $"{ ex.Message}",
                    (string)System.Windows.Application.Current.FindResource("ErreurDeValidation"),
                    MessageBoxButton.OK,
                    MessageBoxImage.Warning);
            }
            catch (InvalidOperationException ex)
            {
                // Gestion des erreurs liées à des règles métier non respectées
                MessageBox.Show(
                    $"{ex.Message}",
                    (string)System.Windows.Application.Current.FindResource("ErreurDeValidation"),
                    MessageBoxButton.OK,
                    MessageBoxImage.Warning);
            }
            catch (ApplicationException ex)
            {
                // Gestion des erreurs générales encapsulées dans ApplicationException
                MessageBox.Show(
                    $"{ex.InnerException?.Message ?? ex.Message}", 
                    (string)System.Windows.Application.Current.FindResource("ErreurDeMiseAJour"),
                    MessageBoxButton.OK,
                    MessageBoxImage.Error);
            }
            catch (Exception ex)
            {
                // Gestion des erreurs inattendues
                MessageBox.Show(
                    $"{ex.Message}",
                    (string)System.Windows.Application.Current.FindResource("ErreurInnatendue"),
                    MessageBoxButton.OK,
                    MessageBoxImage.Error);
            }
        }

        private void ClickBtnAnnuler(object sender, RoutedEventArgs e)
        {
            Canceled?.Invoke(this, EventArgs.Empty);
            this.Visibility = Visibility.Collapsed;
        }
    }
}
  