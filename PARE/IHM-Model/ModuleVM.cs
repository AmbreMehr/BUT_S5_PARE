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
        private List<TeacherVM> teachersInCharge;

        /// <summary>
        /// Récupère et remplace la liste des professeurs intervenant sur le module
        /// </summary>
        public List<TeacherVM> TeachersInCharge
        {
            get => teachersInCharge;
            set
            {
                if (teachersInCharge != value)
                {
                    teachersInCharge = value;
                    NotifyChange();
                }
            }
        }


        /// <summary>
        /// Récupère et remplace le nom du module
        /// </summary>
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

        /// <summary>
        /// Récupère et remplace la semaine de commencement d'un module
        /// </summary>
        public int WeekBegin
        {
            get => model.WeekBegin;
            set => model.WeekBegin = value;
        }

        /// <summary>
        /// Récupère et remplace la semaine de fin d'un module
        /// </summary>
        public int WeekEnd
        {
            get => model.WeekEnd;
            set => model.WeekEnd = value;
        }

        /// <summary>
        /// Récupère et remplace le nombre d'heures de TD du module
        /// </summary>
        public int HoursTd
        {
            get => model.HoursTd;
            set => model.HoursTd = value;
        }

        /// <summary>
        /// Récupère et remplace le nombre d'heures de TP du module
        /// </summary>
        public int HoursTp
        {
            get => model.HoursTp;
            set => model.HoursTp = value;
        }

        /// <summary>
        /// Récupère et remplace le nombre d'heures de CM du module
        /// </summary>
        public int HoursCM
        {
            get => model.HoursCM;
            set => model.HoursCM = value;
        }

        /// <summary>
        /// Récupère et remplace le responsable du module
        /// </summary>
        public UserVM Supervisor
        {
            get => new UserVM(model.Supervisor);
            set => model.Supervisor = value.Model;
        }

        /// <summary>
        /// Récupère le model du VM, utile aux autres VM
        /// </summary>
        public Module Model
        {
            get => model;
        }

        /// <summary>
        /// Async, Met à jour le modèle dans l'API
        /// </summary>
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
            this.teachersInCharge = new List<TeacherVM>();
        }

        /// <summary>
        /// Constructeur de la classe ModuleVM sans modèle, initialise un modèle vide
        /// </summary>
        public ModuleVM()
        {
            model = new Module();
            moduleNetwork = new ModuleNetwork();
            this.teachersInCharge = new List<TeacherVM>();
        }
    }
}
