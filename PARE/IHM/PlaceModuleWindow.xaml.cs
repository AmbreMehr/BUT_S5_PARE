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
            
            UpdateModulesList();
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
            await modulesVM.UpdateModules();
            ValidationCompleted?.Invoke(this, EventArgs.Empty);
            await UpdateModulesList();
            this.Visibility = Visibility.Collapsed;
        }
        private void ClickBtnAnnuler(object sender, RoutedEventArgs e)
        {
            Canceled?.Invoke(this, EventArgs.Empty);
            this.Visibility = Visibility.Collapsed;
        }
    }
}
  