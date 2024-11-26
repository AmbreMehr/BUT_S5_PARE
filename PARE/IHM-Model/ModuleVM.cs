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
        private Module model;

        public string Name
        {
            get => model.Name;
            set
            {
                if (model.Name != value)
                {
                    model.Name = value;
                    NotifyChange();
                }
            }
        }

        public int WeekBegin
        {
            get => model.WeekBegin;
            set => model.WeekBegin = value;
        }

        public int WeekEnd
        {
            get => model.WeekEnd;
            set => model.WeekEnd = value;
        }

        public UserVM Supervisor
        {
            get => new UserVM(model.Supervisor);
            set => model.Supervisor = value.Model;
        }

        public Module Model
        {
            get => model;
        }

        public async Task UpdateModule()
        {

        }

        /// <summary>
        /// Constructeur de la classe ModulesVM avec son modèle.
        /// </summary>
        /// <param name="model">Object Module</param>
        public ModuleVM(Module module)
        {
            this.model = module;
        }

        /// <summary>
        /// Constructeur de la classe ModuleVM sans modèle, initialise un modèle vide
        /// </summary>
        public ModuleVM()
        {
            model = new Module();
        }
    }
}
