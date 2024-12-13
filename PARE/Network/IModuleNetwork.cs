using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Network
{
    /// <summary>
    /// Interface de réseau pour gérer les modules
    /// </summary>
    public interface IModuleNetwork
    {
        /// <summary>
        /// Async, met à jour le module
        /// </summary>
        /// <param name="module">Module</param>
        /// <returns>HTTP Code</returns>
        Task UpdateModule(Module module);

        /// <summary>
        /// Async, renvoie les modules contenus dans un semestre
        /// </summary>
        /// <param name="semester">Semester</param>
        /// <returns>Liste de Module du semestre</returns>
        Task<Module[]> GetModuleBySemester(int semester);

        /// <summary>
        /// Asyncn, renvoie tous les modules
        /// </summary>
        /// <returns>Liste de Module</returns>
        Task<Module[]> GetAllModules();
    }
}
