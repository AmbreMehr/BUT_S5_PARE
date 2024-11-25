﻿using IHM_Model;
using System;
using System.Collections.Generic;
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
    /// Logique d'interaction pour EditModuleWindow.xaml
    /// <author>Clotilde MALO</author>
    /// </summary>
    public partial class EditModuleWindow : Window
    {
        private SemesterVM semesterVM;

        public EditModuleWindow(SemesterVM semester)
        {
            this.semesterVM = semester;
            InitializeComponent();

            // TEST A REMPLACER : Créé un faux module
            AddModule("Module 1");
            AddModule("Module 1");
            AddModule("Module 1");
            AddModule("Module 1");
            AddModule("Module 1");

        }



        /// <summary>
        /// Ajoute un module à l'interface
        /// <author>Clotilde MALO</author>
        /// </summary>
        /// <param name="moduleName">nom du module</param>
        private void AddModule(string moduleName)
        {
            StackPanel module = new StackPanel { Margin = new Thickness(0, 10, 0, 10) };

            TextBlock moduleTitle = new TextBlock
            {
                Text = moduleName,
                FontSize = 16,
                FontWeight = FontWeights.Bold,
                Margin = new Thickness(0, 0, 0, 5),
                HorizontalAlignment = HorizontalAlignment.Center
            };
            module.Children.Add(moduleTitle);

            AddGridHeaders(module);


            StackPanel teacherContainer = new StackPanel();
            module.Children.Add(teacherContainer);
            AddTeacherButton(teacherContainer, module);


            AddTeacherRow(teacherContainer);

            modulesPanel.Children.Add(module);

        }

        /// <summary>
        /// Ajoute l'entete du tableau des enseignants/heures
        /// <author>Clotilde MALO</author>
        /// </summary>
        /// <param name="moduleStack">panneau de module</param>
        private void AddGridHeaders(StackPanel moduleStack)
        {
            StackPanel headerStack = new StackPanel
            {
                Orientation = Orientation.Horizontal,
                HorizontalAlignment = HorizontalAlignment.Center,
                Margin = new Thickness(5)
            };

            headerStack.Children.Add(new TextBlock { Text = (string)Application.Current.FindResource("ProgramModule"), Width = 120, FontWeight = FontWeights.Bold });
            headerStack.Children.Add(new TextBlock { Text = (string)Application.Current.FindResource("TD"), Width = 50, FontWeight = FontWeights.Bold });
            headerStack.Children.Add(new TextBlock { Text = (string)Application.Current.FindResource("TP"), Width = 50, FontWeight = FontWeights.Bold });
            headerStack.Children.Add(new TextBlock { Text = (string)Application.Current.FindResource("CM"), Width = 50, FontWeight = FontWeights.Bold });

            moduleStack.Children.Add(headerStack);
        }

        /// <summary>
        /// Ajoute une ligne d'enseignant/heure
        /// <author>Clotilde MALO</author>
        /// </summary>
        /// <param name="moduleStack">panneau de module</param>
        private void AddTeacherRow(StackPanel moduleStack)
        {
            StackPanel rowStack = new StackPanel
            {
                Orientation = Orientation.Horizontal,
                HorizontalAlignment = HorizontalAlignment.Center,
                Margin = new Thickness(5)
            };

            ComboBox teacherComboBox = new ComboBox { Width = 120, Margin = new Thickness(5) };

            // TEST A REMPLACER : a remplir avec tous les profs après
            teacherComboBox.Items.Add("M. Bidule");
            teacherComboBox.Items.Add("Mme Machin");


            TextBox tdBox = new TextBox { Width = 50, Margin = new Thickness(5) };
            TextBox tpBox = new TextBox { Width = 50, Margin = new Thickness(5) };
            TextBox cmBox = new TextBox { Width = 50, Margin = new Thickness(5) };



            rowStack.Children.Add(teacherComboBox);
            rowStack.Children.Add(tdBox);
            rowStack.Children.Add(tpBox);
            rowStack.Children.Add(cmBox);
            DeleteTeacherButton(rowStack, moduleStack);

            moduleStack.Children.Add(rowStack);
        }

        /// <summary>
        /// Ajoute un bouton pour supprimer une ligne d'enseignant/heure
        /// <author>Clotilde MALO</author>
        /// </summary>
        /// <param name="row">ligne à supprimer</param>
        /// <param name="module">panneau de module</param>
        private void DeleteTeacherButton(StackPanel row, StackPanel module)
        {
            Button deleteButton = new Button
            {
                Content = (string)Application.Current.FindResource("SupprimerEnseignant"),
                Width = 200,
                Margin = new Thickness(5)
            };
            deleteButton.Click += (sender, e) => module.Children.Remove(row);
            row.Children.Add(deleteButton);

        }

        /// <summary>
        /// Ajoute un bouton pour ajouter une ligne d'enseignant/heure
        /// <author>Clotilde MALO</author>
        /// </summary>
        /// <param name="teacherContainer">panneau d'enseignant</param>
        /// <param name="module">panneau de module</param>
        private void AddTeacherButton(StackPanel teacherContainer, StackPanel module)
        {
            Button addButton = new Button
            {
                Content = (string)Application.Current.FindResource("AjoutEnseignant"),
                Width = 200,
                Margin = new Thickness(5),
                HorizontalAlignment = HorizontalAlignment.Center
            };
            addButton.Click += (sender, e) => AddTeacherRow(teacherContainer);

            module.Children.Add(addButton);
        }

        /// <summary>
        /// Au clic sur confirmer : enregistre les modifications
        /// <author>Clotilde MALO</author>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UpdateTeacher(object sender, RoutedEventArgs e)
        {
            // TO DO : envoyer à VM

            MessageBox.Show((string)Application.Current.FindResource("MessageModif"), (string)Application.Current.FindResource("Confirmation"), MessageBoxButton.OK, MessageBoxImage.Information);

        }


        /// <summary>
        /// Au clic sur annuler : retourne à la page d'accueil
        /// <author>Clotilde MALO</author>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BackHome(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }
    }
}
