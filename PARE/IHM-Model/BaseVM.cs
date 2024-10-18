using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace IHM_Model
{
    /// <summary>
    /// La classe de base `BaseVM` implémente l'interface INotifyPropertyChanged.
    /// </summary>
    /// <author>Stéphane BASSET</author>
    public class BaseVM : INotifyPropertyChanged
    {
        /// <summary>
        /// Événement déclenché lorsque la valeur d'une propriété est modifiée. Il permet aux interfaces utilisateur de réagir aux changements des données.
        /// </summary>
        /// <author>Stéphane BASSET</author>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Elle déclenche l'événement PropertyChanged avec le nom de la propriété modifiée.
        /// L'attribut [CallerMemberName] permet de passer automatiquement le nom de la propriété appelante.
        /// </summary>
        /// <param name="propertyName">
        /// Nom de la propriété qui a changé. Si aucun nom n'est spécifié, l'attribut CallerMemberName passe automatiquement le nom de la propriété appelante.
        /// </param>
        /// <author>Stéphane BASSET</author>
        protected void NotifyChange([CallerMemberName] string propertyName = null)
        {
            
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
