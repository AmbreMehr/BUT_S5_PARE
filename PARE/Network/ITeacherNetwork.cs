using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Network
{
    public interface ITeacherNetwork
    {
        /// <summary>
        /// Async, renvoie tous les enseignants qui sont asignés au module
        /// </summary>
        /// <param name="module">Module enseigné</param>
        /// <returns>Liste de Teacher</returns>
        Task<Teacher[]> GetTeachersByModule(Module module);

        /// <summary>
        /// Async, met à jour l'enseignant
        /// </summary>
        /// <param name="teacher">Teacher</param>
        /// <returns>HTTP Code</returns>
        Task UpdateTeacher(Teacher teacher);

        /// <summary>
        /// Async, supprime l'enseignant
        /// </summary>
        /// <param name="teacher">Teacher</param>
        /// <returns>HTTP Code</returns>
        Task DeleteTeacher(Teacher teacher);

        /// <summary>
        /// Async, crée l'enseignant
        /// </summary>
        /// <param name="teacher">Teacher</param>
        /// <returns>HTTP Code</returns>
        Task CreateTeacher(Teacher teacher);
    }
}
