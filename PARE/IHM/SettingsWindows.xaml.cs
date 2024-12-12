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
    /// Logique d'interaction pour SettingsWindows.xaml
    /// </summary>
    public partial class SettingsWindows : Window
    {
        private LANGUE langueinitiale;
        public SettingsWindows()
        {
            InitializeComponent();
            langueinitiale = Parametre.Instance.Langue;
        }

        /// <summary>
        /// Au clic sur quitter sauvegarde et ferme l'application
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Quit(object sender, RoutedEventArgs e)
        {
            Save();
            this.Close();

        }

        /// <summary>
        /// Sauvegarde les données de langue
        /// </summary>
        private void Save()
        {
            JsonSerializerParametre jsonSave = new JsonSerializerParametre();
            jsonSave.Save();
        }

        /// <summary>
        /// Sélectionne la langue Française
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SelectionnerLangueFR(object sender, RoutedEventArgs e)
        {
            Parametre.Instance.Langue = LANGUE.FRANCAIS;
        }

        /// <summary>
        /// Séléctionne la langue Anglaise
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SelectionnerLangueEN(object sender, RoutedEventArgs e)
        {
            Parametre.Instance.Langue = LANGUE.ANGLAIS;
        }

        /// <summary>
        /// A la fermeture de la fenêtre, sauvegarde et ferme l'application
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Save();
        }
    }
}
