using IHM.PaternObserver;
using System.Configuration;
using System.Data;
using System.Runtime.CompilerServices;
using System.Windows;

namespace IHM
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application, IObservateur
    {
        /// <summary>
        /// Constructeur qui initialise les parametres
        /// </summary>
        public App()
        {
            this.InitializeComponent();

            Parametre.Instance.Register(this);

        }

        /// <summary>
        /// Quand les parametres change on notifie l'app (pour changer la langue)
        /// </summary>
        /// <param name="Message">langue modifié dans les parametres</param>
        /// <author>Lucas</author>
        public void Notifier(string Message)
        {
            ResourceDictionary dictionnaire = new ResourceDictionary();

            switch (Message)
            {
                case "ANGLAIS":
                    dictionnaire.Source = new Uri("Ressources\\Res\\StringResources.en.xaml", UriKind.Relative);
                    break;
                case "FRANCAIS":
                    dictionnaire.Source = new Uri("Ressources\\Res\\StringResources.fr.xaml", UriKind.Relative);
                    break;
                default:
                    dictionnaire.Source = new Uri("Ressources\\Res\\StringResources.fr.xaml", UriKind.Relative);
                    break;
            }
            //Change la ressource utilisé par l'application
            App.Current.Resources.MergedDictionaries.Add(dictionnaire);
        }
    }

}
