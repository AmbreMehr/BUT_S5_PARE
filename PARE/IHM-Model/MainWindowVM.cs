using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IHM_Model
{
    /// <summary>
    /// Permet de regrouper les 2 VM (modules et semestre) pour les passer à la vue principale
    /// </summary>
    /// <author> Clotilde MALO</author>
    public class MainViewModel
    {
        /// <summary>
        /// Get et set du ViewModel des modules
        /// </summary>
        public ModulesVM ModulesVM { get; set; }

        /// <summary>
        /// Get et set du ViewModel des semestres
        /// </summary>
        public SemesterVM SemesterVM { get; set; }

        /// <summary>
        /// Constructeur de la classe MainViewModel 
        /// </summary>
        /// <param name="modulesVM">modules view model</param>
        /// <param name="semesterVM">semestre view model</param>

        public MainViewModel(ModulesVM modulesVM, SemesterVM semesterVM)
        {
            this.ModulesVM = modulesVM;
            this.SemesterVM = semesterVM;
        }
    }

}
