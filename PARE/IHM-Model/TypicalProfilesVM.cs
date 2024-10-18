using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IHM_Model
{
    /// <summary>
    /// La classe TypicalProfileVM gère les Profil type des teacher
    /// Le setter déclenche une notification de changement.
    /// </summary>
    /// /// <author>Stéphane BASSET</author>
    public class TypicalProfilesVM : BaseVM
    {
        
        private TypicalProfile[] _model;

        /// <summary>
        /// Propriété pour obtenir ou définir le tableau de profils typiques.
        /// </summary>
        public TypicalProfile[] ProfilType
        {
            get { return _model; }
            set
            {
                _model = value;
                NotifyChange("ProfilType");
            }
        }

        /// <summary>
        /// Récupère les TypicalProfile pour un teacher donné.
        /// </summary>
        /// <returns>Tableau des modules pour le semestre</returns>
        /// <author>Stéphane BASSET</author>
        public TypicalProfile[] GetAllTypicalProfile()
        {
            // A faire: Implémenter la logique ici pour retourner les TypicalProfile associés à un teacher
            return _model; // Retourne le tableau des TypicalProfile, peut être modifié selon la logique

        }
    }
}
