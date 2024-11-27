﻿using Model;
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

        /// <summary>
        /// Get et set pour le nom du module
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
        /// Get et set pour la semaine de commencement d'un module
        /// </summary>
        public int WeekBegin
        {
            get => model.WeekBegin;
            set => model.WeekBegin = value;
        }

        /// <summary>
        /// Get et set pour la semaine de fin d'un module
        /// </summary>
        public int WeekEnd
        {
            get => model.WeekEnd;
            set => model.WeekEnd = value;
        }

        /// <summary>
        /// Get et set pour le nombre d'heures de TD du module
        /// </summary>
        public int HoursTd
        {
            get => model.HoursTd;
            set => model.HoursTd = value;
        }

        /// <summary>
        /// Get et set pour le nombre d'heures de TP du module
        /// </summary>
        public int HoursTp
        {
            get => model.HoursTp;
            set => model.HoursTp = value;
        }

        /// <summary>
        /// Get et set pour le nombre d'heures de CM du module
        /// </summary>
        public int HoursCM
        {
            get => model.HoursCM;
            set => model.HoursCM = value;
        }

        /// <summary>
        /// Get et set pour le responsable du module
        /// </summary>
        public UserVM Supervisor
        {
            get => new UserVM(model.Supervisor);
            set => model.Supervisor = value.Model;
        }

        /// <summary>
        /// Get pour le model du VM, utile aux autres VM
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
