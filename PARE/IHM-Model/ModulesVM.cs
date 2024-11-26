using Model;
using Network;
using System;
using System.Collections.ObjectModel;
using System.Reflection;
using System.Threading.Tasks;
using Module = Model.Module;

namespace IHM_Model
{
    /// <summary>
    /// La classe `ModulesVM` gère les modules dans l'application PARE.
    /// </summary>
    /// <author>Stéphane BASSET - Clotilde MALO</author>
    public class ModulesVM : BaseVM
    {
        private ObservableCollection<Module> _models;
        private Module _selectedModule;
        private IModuleNetwork _moduleNetwork;

        /// <summary>
        /// Get et set du tableau de modules
        /// </summary>
        /// <author> Clotilde MALO </author>
        public ObservableCollection<Module> Modules
        {
            get { return _models; }
            set
            {
                _models = value;
                NotifyChange("Modules");
            }
        }
        /// <summary>
        /// Get et set du module sélectionné
        /// </summary>
        /// <author> Clotilde MALO </author>
        public Module SelectedModule
        {
            get { return _selectedModule; }
            set
            {
                _selectedModule = value;
                NotifyChange("SelectedModule");
            }
        }


        /// <summary>
        /// Constructeur initialisant le tableau de modules.
        /// </summary>
        /// <author>Stéphane BASSET</author>
        public ModulesVM() 
        {
            this._moduleNetwork = new ModuleNetwork();
            this._models = new ObservableCollection<Module>();
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
        /// <param name="idSemester">id du semestre souhaité</param>
        /// <returns>Tableau des modules pour le semestre</returns>
        /// <author>Stéphane BASSET</author>
        public async Task<ObservableCollection<Module>> GetModuleBySemester(int idSemester)
        {
            Modules = new ObservableCollection<Module>(await _moduleNetwork.GetModuleBySemester(idSemester));
            return Modules; 
        }

        /// <summary>
        /// Fait l'appel pour récupérer les modules pour un semestre donné.
        /// </summary>
        /// <param name="idSemester">id du semestre</param>
        /// <author>Clotilde MALO</author>
        public async Task LoadModulesBySemester(int idSemester)
        {
            Modules = await GetModuleBySemester(idSemester);
        }

        /// <summary>
        /// Récupère tout les modules
        /// </summary>
        /// <returns>tout les modules</returns>
        /// <author>Lucas PRUNIER</author>
        public async Task<ObservableCollection<Module>> GetAllModules()
        {
            Modules = new ObservableCollection<Module>(await _moduleNetwork.GetAllModules());
            return Modules;
        }

        /// <summary>
        /// Met à jour le module sélectionné via le réseau.
        /// </summary>
        /// <returns>Une tâche asynchrone.</returns>
        /// <author>Lucas PRUNIER</author>
        public async Task UpdateModule()
        {
            await _moduleNetwork.UpdateModule(SelectedModule);
            Modules = new ObservableCollection<Module>(await _moduleNetwork.GetAllModules());
            NotifyChange("SelectedModule");
        }
    }
}
