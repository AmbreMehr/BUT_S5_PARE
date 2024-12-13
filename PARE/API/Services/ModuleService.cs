using Microsoft.EntityFrameworkCore;
using Model;
using Storage;
using Storage.InterfaceDAO;

namespace API.Services
{
    public class ModuleService
    {
        private IModuleDao moduleDao;

        public ModuleService()
        {
            this.moduleDao = new ModuleDaoSqlite();
        }

        /// <summary>
        /// Renvoie les modules contenus dans un semestre
        /// </summary>
        /// <param name="semester">Semester semestre qui contient les modules</param>
        /// <returns>Liste de Module</returns>
        /// <author>AmbreMehr</author>
        public Module[] GetModulesForSemester(int semester)
        {
            return this.moduleDao.GetAllBySemester(semester);
        }

        /// <summary>
        /// Renvoie tous les modules
        /// </summary>
        /// <returns>Liste de Module</returns>
        /// <author>AmbreMehr</author>
        public Module[] GetAllModules()
        {
            IEnumerable<Module> module = this.moduleDao.ListAll();
            return module.ToArray();
        }

        /// <summary>
        /// Met à jour le module
        /// </summary>
        /// <param name="module">module à mettre à jour</param>
        public void UpdateModule(Module module)
        {
            moduleDao.Update(module);
        }

    }
}
