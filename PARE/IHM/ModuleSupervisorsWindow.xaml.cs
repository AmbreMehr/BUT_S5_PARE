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

namespace IHM
{
    /// <summary>
    /// Logique d'interaction pour ModuleSupervisorsWindow.xaml
    /// </summary>
    public partial class ModuleSupervisorsWindow : Window
    {
        private ModuleSupervisorsContext context;

        public ModuleSupervisorsWindow(SemestersVM semestersVM)
        {
            context = new ModuleSupervisorsContext(semestersVM);
            DataContext = context;

            InitializeComponent();
            InitializeData();
        }

        private async void InitializeData()
        {
            await context.UsersVM.GetAllProfessors();
            await GetModulesBySemester();
        }

        private async Task GetModulesBySemester()
        {
            if (context.SemestersVM.SelectedSemester != null) 
            {
                foreach (UIElement child in ModuleList.Children.OfType<Border>())
                {
                    ModuleList.Children.Remove(child);
                }
                await context.ModulesVM.GetModuleBySemester(context.SemestersVM.SelectedSemester);
                int iRow = 0;
                foreach (ModuleVM moduleVM in context.ModulesVM.Modules)
                {
                    // Créer une bordure pour le tableau
                    Border moduleSupervisorCell = NewBorder();
                    ComboBox moduleSupervisorBox = new ComboBox
                    {
                        ItemsSource = context.UsersVM.Users,
                        SelectedItem = moduleVM.Supervisor,
                        DisplayMemberPath = "Fullname"
                    };
                    Border moduleNameCell = NewBorder();
                    TextBlock moduleNameBox = new TextBlock
                    {
                        Text = moduleVM.Name,
                        HorizontalAlignment = HorizontalAlignment.Center,
                        VerticalAlignment = VerticalAlignment.Center,
                        FontSize = 18
                    };
                    moduleSupervisorCell.Child = moduleSupervisorBox;
                    moduleNameCell.Child = moduleNameBox;
                    Grid.SetColumn(moduleSupervisorCell, 0);
                    Grid.SetColumn(moduleNameCell, 1);
                    Grid.SetRow(moduleSupervisorCell, iRow);
                    Grid.SetRow(moduleNameCell, iRow);
                    ModuleList.RowDefinitions.Add(new RowDefinition { Height = new GridLength(30) });
                    ModuleList.Children.Add(moduleSupervisorCell);
                    ModuleList.Children.Add(moduleNameCell);
                    iRow++;
                }
            }
        }

        private Border NewBorder()
        {
            return new Border
            {
                BorderBrush = new SolidColorBrush(Colors.Black),
                BorderThickness = new Thickness(2)
            };
        }

        private void ClickCancelButton(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        public struct ModuleSupervisorsContext
        {
            public SemestersVM SemestersVM { get; set; }
            public ModulesVM ModulesVM { get; set; }
            public UsersVM UsersVM { get; set; }

            public ModuleSupervisorsContext(SemestersVM semestersVM)
            {
                SemestersVM = semestersVM;
                ModulesVM = new ModulesVM();
                UsersVM = new UsersVM();
            }
        }
    }
}
