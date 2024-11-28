using IHM_Model;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
        private TeachersVM teachersVMQuery;
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
            this.teachersVMQuery = new TeachersVM();
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
                List<TeacherVM> TeachersVM = await this.teachersVMQuery.GetTeachersByModule(moduleVM);
                foreach (TeacherVM teacherVM in TeachersVM)
                {
                    
                    this.teachersVM.Teachers.Add(teacherVM);
                    AddTeacherRow(modulesPanel, teacherVM);
                }

            }
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
                HorizontalAlignment = HorizontalAlignment.Center,

            };
            module.Children.Add(moduleTitle);

            AddGridHeaders(module);
            AddProgramRow(module, moduleVM);

            StackPanel teacherContainer = new StackPanel();
            module.Children.Add(teacherContainer);
            AddTeacherButton(teacherContainer, module, moduleVM);


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
            // Création de la ligne
            StackPanel rowStack = new StackPanel
            {
                Orientation = Orientation.Horizontal,
                HorizontalAlignment = HorizontalAlignment.Center,
                Margin = new Thickness(5)
            };

            // Création de la liste déroulante + binding
            ComboBox teacherComboBox = new ComboBox { Width = 120, Margin = new Thickness(5) };

            teacherComboBox.ItemsSource = usersVM.Users;
            teacherComboBox.DisplayMemberPath = "Fullname";

            Binding bindingSelected = new Binding("User")
            {
                Source = teacherVM,
                Mode = BindingMode.TwoWay,
                UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged

            };
            teacherComboBox.SetBinding(ComboBox.SelectedItemProperty, bindingSelected);

            // Création des champs avec les heures (TD, TP, CM) + binding
            TextBox tdBox = new TextBox { Width = 50, Margin = new Thickness(5) };
            TextBox tpBox = new TextBox { Width = 50, Margin = new Thickness(5) };
            TextBox cmBox = new TextBox { Width = 50, Margin = new Thickness(5) };


            Binding bindingTd = new Binding("AssignedTdHours")
            {
                Source = teacherVM,
                Mode = BindingMode.TwoWay,
                UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged
            };
            tdBox.SetBinding(TextBox.TextProperty, bindingTd);


            Binding bindingTp = new Binding("AssignedTpHours")
            {
                Source = teacherVM,
                Mode = BindingMode.TwoWay,
                UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged
            };
            tpBox.SetBinding(TextBox.TextProperty, bindingTp);


            Binding bindingCm = new Binding("AssignedCmHours")
            {
                Source = teacherVM,
                Mode = BindingMode.TwoWay,
                UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged
            };
            cmBox.SetBinding(TextBox.TextProperty, bindingCm);


            // Si l'enseignant est déjà enregistré, on le signale
            if (teacherVM.User.Model != null)
            {
                teacherVM.IsInStorage = true;
            }

            // Ajout des éléments à la ligne
            rowStack.Children.Add(teacherComboBox);
            rowStack.Children.Add(tdBox);
            rowStack.Children.Add(tpBox);
            rowStack.Children.Add(cmBox);

            // Appel de la méthode pour ajouter le bouton de suppression
            DeleteTeacherButton(rowStack, moduleStack, teacherVM);

            // Ajout de la ligne au panneau de module
            moduleStack.Children.Add(rowStack);
        }



        /// <summary>
        /// Ajoute un bouton pour supprimer une ligne d'enseignant/heure et gère son clic
        /// <author>Clotilde MALO</author>
        /// </summary>
        /// <param name="row">ligne à supprimer</param>
        /// <param name="module">panneau de module</param>
        private void DeleteTeacherButton(StackPanel row, StackPanel module, TeacherVM teacherVM)
        {
            // Création du bouton
            Button deleteButton = new Button
            {
                Content = (string)System.Windows.Application.Current.FindResource("SupprimerEnseignant"),
                Width = 200,
                Margin = new Thickness(5)
            };
            // Ajout du bouton à la ligne
            row.Children.Add(deleteButton);

            // Gestion du clic sur le bouton : supprime en bdd
            deleteButton.Click += (sender, e) =>
            {
                MessageBoxResult result = MessageBox.Show((string)System.Windows.Application.Current.FindResource("MessageSuppr"), 
                                            (string)System.Windows.Application.Current.FindResource("Confirmation"), MessageBoxButton.YesNo, MessageBoxImage.Question);

               if (result == MessageBoxResult.Yes)
                {
                    module.Children.Remove(row);
                    if (teacherVM.IsInStorage)
                    {
                        DeleteTeacherButton(teacherVM);
                    }
                }
            };

        }
        /// <summary>
        /// Permet d'appeler la méthode de suppression d'un enseignant si l'enseignant est enregistré dans la bdd
        /// </summary>
        /// <param name="teacherVM">VM associé à l'enseignant</param>
        private async void DeleteTeacherButton(TeacherVM teacherVM)
        {
            if (teacherVM.IsInStorage)
            {
                await teacherVM.DeleteTeacher();
            }

        }


        /// <summary>
        /// Ajoute un bouton pour ajouter une ligne d'enseignant/heure et au clic dessus créé un teacherVM et une ligne
        /// <author>Clotilde MALO</author>
        /// </summary>
        /// <param name="teacherContainer">panneau d'enseignant</param>
        /// <param name="module">panneau de module</param>
        private void AddTeacherButton(StackPanel teacherContainer, StackPanel module, ModuleVM moduleVM)
        {
            // Création du bouton
            Button addButton = new Button
            {
                Content = (string)System.Windows.Application.Current.FindResource("AjoutEnseignant"),
                Width = 200,
                Margin = new Thickness(5),
                HorizontalAlignment = HorizontalAlignment.Center
            };

            // Ajout du bouton au panneau d'enseignant
            module.Children.Add(addButton);

            // Gestion du clic sur le bouton : ajoute une ligne
            addButton.Click += (sender, e) =>
            {
                TeacherVM teacherVM = new TeacherVM();
                this.teachersVM.Teachers.Add(teacherVM);
                teacherVM.Module = moduleVM;
                AddTeacherRow(teacherContainer, teacherVM);
            };

        }

        /// <summary>
        /// Au clic sur confirmer : enregistre les modifications
        /// <author>Clotilde MALO</author>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void UpdateCreateTeacher(object sender, RoutedEventArgs e)
        {
            foreach (TeacherVM teacherVM in teachersVM.Teachers)
            {
                if (teacherVM.IsInStorage)
                {
                    await teacherVM.UpdateTeacher();

                }
                else
                {
                    await teacherVM.CreateTeacher();
                }

            }

            MessageBox.Show((string)System.Windows.Application.Current.FindResource("MessageModif"), (string)System.Windows.Application.Current.FindResource("Confirmation"), MessageBoxButton.OK, MessageBoxImage.Information);
            BackHome(sender, e);
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