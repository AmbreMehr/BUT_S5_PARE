using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Network
{
    /// <author>AmbreMehr</author>
    public interface ISemesterNetwork
    {
        /// <summary>
        /// Async, renvoie tous les semestres
        /// </summary>
        /// <returns>Liste de Semester</returns>
        Task<Semester[]> GetAllSemesters();

        /// <summary>
        /// Async, renvoie le nombre d'heures des étudiants par semaine, sur le semestre donné
        /// </summary>
        /// <param name="semester">semestre</param>
        /// <returns>Dictionnaire semaine -> heures des étudiants</returns>
        Task<Dictionary<int, float>> GetStudentsHoursPerWeek(Semester semester);
    }
}
