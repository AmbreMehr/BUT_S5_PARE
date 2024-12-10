using IHM_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
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
    /// Logique d'interaction pour BilanDesAlertesWindow.xaml
    /// </summary>
    public partial class BilanDesAlertesWindow : Window
    {
        private UsersVM usersVM;
        public BilanDesAlertesWindow()
        {
            this.usersVM = new UsersVM();
            InitializeComponent();
            DisplayAllTeachers();
        }

        /// <summary>
        /// Affiche toutes les informations dans le tableau 
        /// </summary>
        /// <returns></returns>
        public async Task DisplayAllTeachers()
        {
            List<UserVM> professors = await usersVM.GetAllProfessors();
            int iRow = 0;

            // Retire les modules de l'interface
            foreach (UIElement child in TeacherList.Children.OfType<Border>().ToList())
            {
                TeacherList.Children.Remove(child);
            }

            foreach(UserVM professor in professors)
            {
                Border nameprofessorBorder = NewBorder();
                TextBlock professorNameBlock = new TextBlock();
                CreationCelluleTableau(professorNameBlock, professor.Fullname);

                Border typicalprofilBorder = NewBorder();
                TextBlock typicalprofilBlock = new TextBlock();
                CreationCelluleTableau(typicalprofilBlock, professor.Profile);

                Border serviceBorder = NewBorder();
                TextBlock serviceBlock = new TextBlock();
                CreationCelluleTableau(serviceBlock, professor.ServiceHour.ToString());

                Border realhoursBorder = NewBorder();
                TextBlock realhoursBlock = new TextBlock();
                CreationCelluleTableau(realhoursBlock, professor.RealHours.ToString());

                // Place les nouveaux éléments dans l'IHM
                nameprofessorBorder.Child = professorNameBlock;
                typicalprofilBorder.Child = typicalprofilBlock;
                serviceBorder.Child = serviceBlock;
                realhoursBorder.Child = realhoursBlock;

                Grid.SetColumn(nameprofessorBorder, 0);
                Grid.SetRow(nameprofessorBorder, iRow);

                Grid.SetColumn(typicalprofilBorder, 1);
                Grid.SetRow(typicalprofilBorder, iRow);

                Grid.SetColumn(serviceBorder, 2);
                Grid.SetRow(serviceBorder, iRow);

                Grid.SetColumn(realhoursBorder, 3);
                Grid.SetRow(realhoursBorder, iRow);

                TeacherList.RowDefinitions.Add(new RowDefinition { Height = new GridLength(30) });

                TeacherList.Children.Add(nameprofessorBorder);
                TeacherList.Children.Add(typicalprofilBorder);
                TeacherList.Children.Add(serviceBorder);
                TeacherList.Children.Add(realhoursBorder);

                iRow++;
            }
        }
       
        /// <summary>
        /// Méthode permettant la simplification de la création de cellules dans le tableau
        /// </summary>
        /// <param name="block"></param>
        /// <param name="content"></param>
        private void CreationCelluleTableau(TextBlock block, string content)
        {
            block.Text = content;
            block.HorizontalAlignment = HorizontalAlignment.Center;
            block.VerticalAlignment = VerticalAlignment.Center;
            block.FontSize = 18;
        }

        /// <summary>
        /// Méthode créant une bordure pour chaque élément du tableau
        /// </summary>
        /// <returns></returns>
        private Border NewBorder()
        {
            return new Border
            {
                BorderBrush = new SolidColorBrush(Colors.Black),
                BorderThickness = new Thickness(2)
            };
        }

        /// <summary>
        /// Bouton permettant de revenir à la mainWindow
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RetourMainWindow(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            main.Show();
            this.Close();
        }
    }
}
