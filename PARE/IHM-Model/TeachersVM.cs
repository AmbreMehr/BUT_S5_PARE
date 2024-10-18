using Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IHM_Model
{
    /// <summary>
    /// La classe `TeachersVM` gère les teacher dans l'application PARE.
    /// </summary>
    /// <author>Stéphane BASSET</author>
    public class TeachersVM : BaseVM
    {
        private Teacher[]_model;
        private Module _module;
        
        public Teacher[] Teachers
        {
            get { return _model; }
            set
            {
                _model = value;
                NotifyChange("Teachers");
            }
        }
        public Module Module
        {
            get { return _module; }
            set
            {
                _module = value;
                NotifyChange("Module");
            }
        }



        /// <summary>
        /// Récupère les Teacher pour un modules donné.
        /// </summary>
        /// <returns>Tableau des teacher pour les modules</returns>
        /// <author>Stéphane BASSET</author>
        public Teacher[] GetTeachersByModule(Module module)
        {
            // A faire: Implémenter la logique ici pour retourner les teacher associés à un   modules 
            return _model; // Retourne le tableau des teacher, peut être modifié selon la logique
        }

    }
}
