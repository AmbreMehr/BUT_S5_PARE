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
    /// Logique d'interaction pour LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Logique quand on clique sur le bouton login, on est juste renvoyé sur l'écran principal
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BoutonLogin(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        /// <summary>
        /// L'application est fermée si on clique sur le bouton Close 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CloseLoginWindow(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown(); // Ferme l'application
        }
    }
}
