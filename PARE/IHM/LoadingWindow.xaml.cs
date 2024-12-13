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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace IHM
{
    /// <summary>
    /// Logique d'interaction pour LoadingWindow.xaml
    /// </summary>
    public partial class LoadingWindow : Window
    {
        public LoadingWindow()
        {
            InitializeComponent();
            Loaded += MainWindow_Loaded;

            //Deserialiser les parametres s'ils existent
            JsonSerializerParametre jsonParam = new JsonSerializerParametre();
            jsonParam.Load();
        }

        /// <summary>
        /// Affiche la fenêtre de bienvenue quelque seconde puis renvoi vers la fenetre de promo
        /// </summary>
        /// <author>Lucas</author>
        private async void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            Activate();

            // On affiche quelques secondes la fenêtre
            await Task.Delay(4000);

            // Fondu de fermeture
            DoubleAnimation animation = new DoubleAnimation(1, 0, TimeSpan.FromSeconds(1));
            animation.Completed += (s, args) =>
            {
                // A la fin de l'animation, masquer la fenêtre
                this.Visibility = Visibility.Collapsed;
            };

            this.BeginAnimation(OpacityProperty, animation);

            // On attend la fin de l'animation
            await Task.Delay(1000);

            // On créer et on affiche la fenêtre pour choisir l'année et la promo
            LoginWindow fenetrePromo = new LoginWindow();
            fenetrePromo.Show();

            // On ferme la fenêtre 
            this.Close();
        }
    }
}
