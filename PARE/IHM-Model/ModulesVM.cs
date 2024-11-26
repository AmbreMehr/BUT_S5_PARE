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
        private ModuleVM? _selectedModule;
        private IModuleNetwork _moduleNetwork;

        /// <summary>
        /// Get et set du tableau de modules
        /// </summary>
        /// <author> Clotilde MALO </author>
        public ObservableCollection<ModuleVM> Modules
        {
            get {
                ObservableCollection<ModuleVM> vms = new ObservableCollection<ModuleVM>();
                foreach (Module module in _models)
                {
                    vms.Add(new ModuleVM(module));
                }
                return vms; 
            }
        }

        /// <summary>
        /// Get et set du module sélectionné
        /// </summary>
        /// <author> Clotilde MALO </author>
        public ModuleVM? SelectedModule
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
        public async Task<ObservableCollection<ModuleVM>> GetModuleBySemester(SemesterVM semester)
        {
            Modules.Clear();
            Module[] modules = await _moduleNetwork.GetModuleBySemester(semester.Model.id);
            foreach (Module module in modules)
            {
                ModuleVM moduleVM = new ModuleVM(module);
                Modules.Add(moduleVM);
            }
            return Modules;
        }

        /// <summary>
        /// Récupère tout les modules
        /// </summary>
        /// <returns>tout les modules</returns>
        /// <author>Lucas PRUNIER</author>
        public async Task<ObservableCollection<ModuleVM>> GetAllModules()
        {
            Modules.Clear();
            Module[] modules = await _moduleNetwork.GetAllModules();
            foreach (Module module in modules)
            {
                ModuleVM moduleVM = new ModuleVM(module);
                Modules.Add(moduleVM);
            }
            return Modules;
        }

        /// <summary>
        /// Met à jour les modules dans le backend
        /// </summary>
        /// <returns>Une tâche asynchrone.</returns>
        /// <author>Lucas PRUNIER</author>
        public async Task UpdateModules()
        {
            try
            {
                // Appeler l'API pour mettre à jour tous les modules
                // @TODO Sauvegarder tous les modules, soit en faisant un foreach moduleVM puis moduleVM.Update
                // Soit en envoyant la liste complète de modèles à l'API (autorisé dans un VM de toucher au modèle
            }
            catch (Exception ex)
            {
                // Gérer les erreurs
                throw new ApplicationException("Erreur lors de la mise à jour du module.", ex);
            }
        }
    }
}
