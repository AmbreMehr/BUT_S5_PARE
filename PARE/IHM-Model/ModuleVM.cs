using Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IHM_Model
{
    /// <summary>
    /// La classe `ModulesVM` gère les modules dans l'application PARE.
    /// </summary>
    /// <author>Stéphane BASSET</author>
    public class ModuleVM : BaseVM
    {
        private string _moduleName;
        private Teacher[] _teacher;

        public string ModuleName
        {
            get => _moduleName;
            set
            {
                if (_moduleName != value)
                {
                    _moduleName = value;
                    NotifyChange();
                }
            }
        }

        /// <summary>
        /// Constructeur de la classe ModulesVM, initialisant le nom du module et les enseignants.
        /// </summary>
        /// <param name="moduleName">Nom du module</param>
        /// <param name="teacher">Nom du teacher</param>
        public ModuleVM(string moduleName, string teacher)
        {
            _moduleName = moduleName;
            _teacher = new Teacher[0];
        }
    }
}
