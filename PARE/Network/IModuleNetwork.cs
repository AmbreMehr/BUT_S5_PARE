using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Network
{
    public interface IModuleNetwork
    {
        /// <summary>
        /// Async, met à jour le module
        /// </summary>
        /// <param name="module">Module</param>
        /// <returns>HTTP Code</returns>
        Task UpdateModule(Module module);

        /// <summary>
        /// Async, renvoie le nombre d'heures suivies par les étudiants pour une semaine donnée
        /// </summary>
        /// <param name="week">int numéro de la semaine selon le calendrier civil</param>
        /// <returns>int nombre d'heures suivies par les étudiants</returns>
        Task<int> GetHoursByWeek(int week);

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
