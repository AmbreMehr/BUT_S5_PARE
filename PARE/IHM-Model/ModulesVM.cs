using IHM_Model.Exceptions;
using Model;
using Network;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
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
        private SemesterVM semester;

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
        /// Met à jour les modules dans le backend en validant les données.
        /// </summary>
        /// <returns>Une tâche asynchrone.</returns>
        /// <author>Lucas PRUNIER</author>
        public async Task UpdateModules()
        {
            foreach (var moduleVM in models)
            {
                try
                {
                    ValidateModule(moduleVM);
                    await moduleVM.UpdateModule();
                }
                catch (Exception ex) when (ex is ValidationException || ex is ApplicationException)
                {
                    // Logique centralisée pour la gestion des exceptions
                    throw new ApplicationException(Ressource.StringRes.ErrorMAJModule, ex);
                }
            }
        }

        /// <summary>
        /// Valide les données d'un module.
        /// </summary>
        /// <param name="moduleVM">Le module à valider.</param>
        /// <exception cref="ValidationException">Lancée si les données ne sont pas valides.</exception>
        private void ValidateModule(ModuleVM moduleVM)
        {
            string semesterName = moduleVM.Model.Semester.Name;
            int weekBegin = moduleVM.WeekBegin;
            int weekEnd = moduleVM.WeekEnd;

            if (weekBegin > weekEnd)
            {
                throw new ExceptionWeekBeginAfterWeekEnd(Ressource.StringRes.WeekBeginAfterWeekEnd);
            }

            if (weekBegin == weekEnd)
            {
                throw new ExceptionSameWeekBeginEnd(Ressource.StringRes.SameWeekBeginEnd);
            }

            switch (semesterName)
            {
                case "Semestre 1":
                case "Semestre 3":
                case "Semestre 5":
                    if (weekBegin < 36 || weekEnd > 48)
                    {
                        throw new ExceptionWeekEnd(Ressource.StringRes.WeekEnd);
                    }
                    break;

                case "Semestre 2":
                case "Semestre 4":
                case "Semestre 6":
                    if (weekBegin < 2 || weekEnd > 14)
                    {
                        throw new ExceptionWeekBeginAndWeekEndSemesterEven(Ressource.StringRes.SemesterEven);
                    }
                    break;

                default:
                    throw new ValidationException($"Semestre inconnu : {semesterName}");
            }
        }

    }
}
