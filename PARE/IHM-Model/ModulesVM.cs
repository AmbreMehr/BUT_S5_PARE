using System;
using System.Collections.ObjectModel;
using System.Reflection;

namespace IHM_Model
{
    /// <summary>
    /// La classe `ModulesVM` gère les modules dans l'application PARE.
    /// </summary>
    /// <author>Stéphane BASSET</author>
    public class ModulesVM : BaseVM
    {
        private Module[]_models;

        /// <summary>
        /// Constructeur initialisant le tableau de modules.
        /// </summary>
        /// <author>Stéphane BASSET</author>
        public ModulesVM() 
        {
            _models = new Module[0];
        }

        /// <summary>
        /// Récupère le nombre d'heures pour une semaine donnée.
        /// </summary>
        /// <param name="week">Numéro de la semaine</param>
        /// <returns>Nombre total d'heures pour la semaine</returns>
        /// <author>Stéphane BASSET</author>
        public int GetHourByWeek(int week)
        {

            int totalHours = 0;
            // A faire: Implémenter la logique ici en fonction de l'organisation des modules et des heures
            return totalHours;
        }

        /// <summary>
        /// Récupère les modules pour un semestre donné.
        /// </summary>
        /// <returns>Tableau des modules pour le semestre</returns>
        /// <author>Stéphane BASSET</author>
        public Module[] GetModuleBySemester()
        {
            // A faire: Implémenter la logique ici pour retourner les modules associés à un semestre
            return _models; // Retourne le tableau des modules, peut être modifié selon la logique

        }



    }
}
