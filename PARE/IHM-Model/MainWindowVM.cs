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
        private ModulesVM modulesVM;
        private SemestersVM semestersVM;


        /// <summary>
        /// Renvoie le ViewModel des modules
        /// </summary>
        public ModulesVM ModulesVM {
            get => modulesVM;
        }

        /// <summary>
        /// Renvoie le ViewModel des semestres
        /// </summary>
        public SemestersVM SemestersVM { 
            get => semestersVM;
        }

        /// <summary>
        /// Constructeur de la classe MainViewModel 
        /// </summary>
        /// <param name="modulesVM">modules view model</param>
        /// <param name="semesterVM">semestre view model</param>

        public MainViewModel(ModulesVM modulesVM, SemestersVM semesterVM)
        {
            this.modulesVM = modulesVM;
            this.semestersVM = semesterVM;
        }
    }

}
