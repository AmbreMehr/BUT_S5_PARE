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

        public PlaceModuleWindow(SemestersVM semestersVM, ModulesVM modulesVM)
        {
            InitializeComponent();
            
            this.semestersVM = semestersVM;
            this.modulesVM = modulesVM;
            
            // S'abonner aux changements de semestre
            this.semestersVM.PropertyChanged += SemesterVM_PropertyChanged;
            
            DataContext = new MainViewModel(this.modulesVM, this.semestersVM);
            
            UpdateModulesList();
        }

        private async void SemesterVM_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "SelectedSemester")
            {
                await UpdateModulesList();
            }
        }

        private async Task UpdateModulesList()
        {
            SemesterVM selectedSemester = semestersVM.SelectedSemester;
            if (selectedSemester != null)
            {
                await this.modulesVM.GetModuleBySemester(selectedSemester);
                ModulesList.ItemsSource = this.modulesVM.Modules;
            }
            else
            {
                MessageBox.Show("Veuillez sélectionner un semestre avant de placer les modules.", "Erreur", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private async void ClickBtnValider(object sender, RoutedEventArgs e)
        {
            if (modulesVM.SelectedModule == null)
            {
                MessageBox.Show("Aucun module sélectionné.", "Erreur", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            try
            {
                // Envoyer les modifications au serveur via ModulesVM
                await modulesVM.UpdateModules();

                // Cacher la fenêtre après la validation
                this.Visibility = Visibility.Collapsed;

                MessageBox.Show("Les modifications ont été appliquées avec succès.", "Succès", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors de la mise à jour : {ex.Message}", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void ClickBtnAnnuler(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Collapsed;
        }
    }
}
  