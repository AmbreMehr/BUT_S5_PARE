using Model;
using Network;
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
        private IModuleNetwork moduleNetwork;

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

        public int HoursTd
        {
            get => model.HoursTd;
            set => model.HoursTd = value;
        }
        public int HoursTp
        {
            get => model.HoursTp;
            set => model.HoursTp = value;
        }
        public int HoursCM
        {
            get => model.HoursCM;
            set => model.HoursCM = value;
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
            await moduleNetwork.UpdateModule(model);
        }

        /// <summary>
        /// Constructeur de la classe ModulesVM avec son modèle.
        /// </summary>
        /// <param name="model">Object Module</param>
        public ModuleVM(Module module)
        {
            this.model = module;
            this.moduleNetwork = new ModuleNetwork();
        }

        /// <summary>
        /// Constructeur de la classe ModuleVM sans modèle, initialise un modèle vide
        /// </summary>
        public ModuleVM()
        {
            model = new Module();
            moduleNetwork = new ModuleNetwork();
        }
    }
}
