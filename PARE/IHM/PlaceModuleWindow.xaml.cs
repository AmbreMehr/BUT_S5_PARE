﻿using IHM_Model;
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
    public partial class PlaceModuleWindow : Window
    {
        private SemesterVM semesterVM;
        private ModulesVM modulesVM;

        public PlaceModuleWindow(SemesterVM semesterVM, ModulesVM modulesVM)
        {
            InitializeComponent();
            
            this.semesterVM = semesterVM;
            this.modulesVM = modulesVM;
            
            // S'abonner aux changements de semestre
            this.semesterVM.PropertyChanged += SemesterVM_PropertyChanged;
            
            DataContext = new MainViewModel(this.modulesVM, this.semesterVM);
            
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
            Semester selectedSemester = semesterVM.SelectedSemester;

            if (selectedSemester != null)
            {
                await this.modulesVM.LoadModulesBySemester(selectedSemester.Id);
                ModulesList.ItemsSource = this.modulesVM.Modules;
            }
            else
            {
                MessageBox.Show("Veuillez sélectionner un semestre avant de placer les modules.", "Erreur", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void ClickBtnValider(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Collapsed;
        }

        private void ClickBtnAnnuler(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Collapsed;
        }
    }
}
