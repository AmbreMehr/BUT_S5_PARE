using IHM_Model;
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
using static System.Net.Mime.MediaTypeNames;

namespace IHM
{
    /// <summary>
    /// Logique d'interaction pour EditModuleWindow.xaml
    /// <author>Clotilde MALO</author>
    /// </summary>
    public partial class EditModuleWindow : Window
    {
        private SemestersVM semestersVM;
        private ModulesVM modulesVM;
        private TeachersVM teachersVM;
        private UsersVM usersVM;

        /// <summary>
        /// Initialise la fenêtre d'édition de module
        /// <author>Clotilde MALO</author>
        /// </summary>
        /// <param name="semesterVM">VM de semestre de la mainwindow</param>
        public EditModuleWindow(SemestersVM semestersVM)
        {
            this.semestersVM = semestersVM;
            this.modulesVM = new ModulesVM();
            this.teachersVM = new TeachersVM();
            this.usersVM = new UsersVM();
            InitializeComponent();
            InitializeAllProfessors();
            InitializeSemesterBox(this.semestersVM);
        }

        /// <summary>
        /// Initialise la récupération de tous les utilisateurs rôle professeurs
        /// </summary>
        private async void InitializeAllProfessors()
        {
            await usersVM.GetAllProfessors();

        }

        /// <summary>
        /// Récupère les modules selon le semestre et les ajoute à la fenêtre
        /// </summary>
        private async void GetModulesBySemester()
        {
            modulesPanel.Children.Clear();
            await this.modulesVM.GetModuleBySemester(semestersVM.SelectedSemester);
            foreach (ModuleVM moduleVM in modulesVM.Modules)
            {
                AddModule(moduleVM);
                List<TeacherVM> TeachersVM = await GetTeachersByModule(moduleVM);
                foreach (TeacherVM teacherVM in TeachersVM)
                {
                    AddTeacherRow(modulesPanel, teacherVM);
                    teachersVM.SelectedTeacher = teacherVM;
                }

            }
            }

         private async Task<List<TeacherVM>> GetTeachersByModule(ModuleVM Module)
         {
             // à voir quoi clear
             return await this.teachersVM.GetTeachersByModule(Module);

         }



        /// <summary>
        /// Initialise la liste déroulante des semestres
        /// <author>Clotilde MALO</author>
        /// </summary>
        /// <param name="semesterVM">VM de semestre avec les données</param>
        private void InitializeSemesterBox(SemestersVM semestersVM)
        {
            semesterBox.DataContext = semestersVM;
            semesterBox.SelectedItem = semestersVM.SelectedSemester;
            semesterBox.ItemsSource = semestersVM.Semesters;
            semesterBox.DisplayMemberPath = "Name";
        }


        /// <summary>
        /// Ajoute un module à l'interface
        /// <author>Clotilde MALO</author>
        /// </summary>
        /// <param name="moduleName">nom du module</param>
        private void AddModule(ModuleVM moduleVM)
        {
            StackPanel module = new StackPanel { Margin = new Thickness(0, 10, 0, 10) };

            TextBlock moduleTitle = new TextBlock
            {
                Text = moduleVM.Name,
                FontSize = 16,
                FontWeight = FontWeights.Bold,
                Margin = new Thickness(0, 0, 0, 5),
                HorizontalAlignment = HorizontalAlignment.Center
            };
            module.Children.Add(moduleTitle);

            AddGridHeaders(module);
            AddProgramRow(module, moduleVM);

            StackPanel teacherContainer = new StackPanel();
            module.Children.Add(teacherContainer);
            AddTeacherButton(teacherContainer, module);


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

            headerStack.Children.Add(new TextBlock { Text = (string)System.Windows.Application.Current.FindResource("TD"), Width = 50, FontWeight = FontWeights.Bold });
            headerStack.Children.Add(new TextBlock { Text = (string)System.Windows.Application.Current.FindResource("TP"), Width = 50, FontWeight = FontWeights.Bold });
            headerStack.Children.Add(new TextBlock { Text = (string)System.Windows.Application.Current.FindResource("CM"), Width = 50, FontWeight = FontWeights.Bold });


            moduleStack.Children.Add(headerStack);
        }

        /// <summary>
        /// Ajoute la ligne avec les heures au programme
        /// </summary>
        /// <param name="moduleStack"></param>
        private void AddProgramRow(StackPanel moduleStack, ModuleVM moduleVM)
        {
            StackPanel programStack = new StackPanel
            {
                Orientation = Orientation.Horizontal,
                HorizontalAlignment = HorizontalAlignment.Center,
                Margin = new Thickness(5)
            };

            TextBlock programBlock = new TextBlock { Text = (string)System.Windows.Application.Current.FindResource("ProgramModule"), Width = 120, FontWeight = FontWeights.Bold };

            TextBlock tdBlock = new TextBlock { Text = moduleVM.HoursTd.ToString(), Width = 120, FontWeight = FontWeights.Bold };
            TextBlock tpBlock = new TextBlock { Text = moduleVM.HoursTp.ToString(), Width = 120, FontWeight = FontWeights.Bold };
            TextBlock cmBlock = new TextBlock { Text = moduleVM.HoursCM.ToString(), Width = 120, FontWeight = FontWeights.Bold };

            programStack.Children.Add(programBlock);
            programStack.Children.Add(tdBlock);
            programStack.Children.Add(tpBlock);
            programStack.Children.Add(cmBlock);


            moduleStack.Children.Add(programStack);
        }

        /// <summary>
        /// Ajoute une ligne d'enseignant/heure
        /// <author>Clotilde MALO</author>
        /// </summary>
        /// <param name="moduleStack">panneau de module</param>
        /// <param name="teacherVM">teacher à ajouter => peut être null si on ajoute une ligne vide</param>
        private void AddTeacherRow(StackPanel moduleStack, TeacherVM teacherVM)
        {
            StackPanel rowStack = new StackPanel
            {
                Orientation = Orientation.Horizontal,
                HorizontalAlignment = HorizontalAlignment.Center,
                Margin = new Thickness(5)
            };

            ComboBox teacherComboBox = new ComboBox { Width = 120, Margin = new Thickness(5) };

            teacherComboBox.SelectedItem = teacherVM.User;
            teacherComboBox.ItemsSource = usersVM.Users;
            teacherComboBox.DisplayMemberPath = "Fullname";

            // Evenement sur modification de la liste déroulante enseignant
            teacherComboBox.SelectionChanged += (sender, e) =>
            {
                teachersVM.SelectedTeacher = (TeacherVM)teacherComboBox.SelectedItem;
            };

            TextBox tdBox = new TextBox { Width = 50, Margin = new Thickness(5) };
            TextBox tpBox = new TextBox { Width = 50, Margin = new Thickness(5) };
            TextBox cmBox = new TextBox { Width = 50, Margin = new Thickness(5) };

            if (teacherVM.User != null)
            {
                teacherComboBox.SelectedItem = teacherVM;
                tdBox.Text = teacherVM.AssignedTdHours.ToString();
                tpBox.Text = teacherVM.AssignedTpHours.ToString();
                cmBox.Text = teacherVM.AssignedCmHours.ToString();
            }



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
                Content = (string)System.Windows.Application.Current.FindResource("SupprimerEnseignant"),
                Width = 200,
                Margin = new Thickness(5)
            };
            deleteButton.Click += (sender, e) => module.Children.Remove(row);
            row.Children.Add(deleteButton);

        }

        /// <summary>
        /// Ajoute un bouton pour ajouter une ligne d'enseignant/heure et au clic dessus créé un teacherVM et une ligne
        /// <author>Clotilde MALO</author>
        /// </summary>
        /// <param name="teacherContainer">panneau d'enseignant</param>
        /// <param name="module">panneau de module</param>
        private void AddTeacherButton(StackPanel teacherContainer, StackPanel module)
        {
            Button addButton = new Button
            {
                Content = (string)System.Windows.Application.Current.FindResource("AjoutEnseignant"),
                Width = 200,
                Margin = new Thickness(5),
                HorizontalAlignment = HorizontalAlignment.Center
            };
            addButton.Click += (sender, e) =>
            {
                TeacherVM teacherVM = new TeacherVM();
                AddTeacherRow(teacherContainer, teacherVM);
            };

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

            MessageBox.Show((string)System.Windows.Application.Current.FindResource("MessageModif"), (string)System.Windows.Application.Current.FindResource("Confirmation"), MessageBoxButton.OK, MessageBoxImage.Information);

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

        /// <summary>
        /// A la modification du semestre permet de modifier les modules
        /// <author>Clotilde MALO</author>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SemestersChange(object sender, SelectionChangedEventArgs e)
        {
            semestersVM.SelectedSemester = (SemesterVM)semesterBox.SelectedItem;
            GetModulesBySemester();
        }
    }
}
