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
        private ObservableCollection<ModuleVM> models;
        private ModuleVM? selectedModule;
        private IModuleNetwork moduleNetwork;

        /// <summary>
        /// Get et set du tableau de modules
        /// </summary>
        /// <author> Clotilde MALO </author>
        public ObservableCollection<ModuleVM> Modules
        {
            get => models;
        }

        /// <summary>
        /// Get et set du module sélectionné
        /// </summary>
        /// <author> Clotilde MALO </author>
        public ModuleVM? SelectedModule
        {
            get { return selectedModule; }
            set
            {
                selectedModule = value;
                NotifyChange("SelectedModule");
            }
        }

        /// <summary>
        /// Constructeur initialisant le tableau de modules.
        /// </summary>
        /// <author>Stéphane BASSET</author>
        public ModulesVM() 
        {
            this.moduleNetwork = new ModuleNetwork();
            this.models = new ObservableCollection<ModuleVM>();
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
        /// <author>Ambre Mehr</author>
        public async Task<ObservableCollection<ModuleVM>> GetModuleBySemester(SemesterVM semester)
        {
            Modules.Clear();
            Module[] modules = await moduleNetwork.GetModuleBySemester(semester.Model.Id);
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
        /// <author>Ambre Mehr</author>
        public async Task<ObservableCollection<ModuleVM>> GetAllModules()
        {
            Modules.Clear();
            Module[] modules = await moduleNetwork.GetAllModules();
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
                // Demande à tous les ModuleVM de mettre à jour le modèle en backend
                foreach (ModuleVM moduleVM in models)
                {
                    await moduleVM.UpdateModule();
                }
            }
            catch (Exception ex)
            {
                // Gérer les erreurs
                // @TODO Les textes d'erreur doivent être en fichier de ressource
                throw new ApplicationException("Erreur lors de la mise à jour du module.", ex);
            }
        }
    }
}
