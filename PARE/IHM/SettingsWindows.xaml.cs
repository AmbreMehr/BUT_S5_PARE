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

        private void ValiderParam(object sender, RoutedEventArgs e)
        {
            //on sauvegarde les paramètres
            JsonSerializerParametre jsonSave = new JsonSerializerParametre();
            jsonSave.Save();

            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }
        private void Cancel(object sender, RoutedEventArgs e)
        {
            Parametre.Instance.Langue = langueinitiale;

            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        private void SelectionnerLangueFR(object sender, RoutedEventArgs e)
        {
            Parametre.Instance.Langue = LANGUE.FRANCAIS;
        }

        private void SelectionnerLangueEN(object sender, RoutedEventArgs e)
        {
            Parametre.Instance.Langue = LANGUE.ANGLAIS;
        }
    }
}
