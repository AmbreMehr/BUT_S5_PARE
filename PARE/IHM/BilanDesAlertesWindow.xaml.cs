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


        public async Task DisplayAllTeachers()
        {
           
            List<UserVM> professors = await usersVM.GetAllProfessors();
            // Retire les modules de l'interface
            foreach (UIElement child in TeacherList.Children.OfType<Border>().ToList())
            {
                TeacherList.Children.Remove(child);
            }

            foreach(UserVM professor in professors)
            {

            }
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
            this.Close();
            main.Show();
        }
    }
}
