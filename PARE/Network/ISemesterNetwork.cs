using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Network
{
    public interface ISemesterNetwork
    {
        /// <summary>
        /// Async, renvoie tous les semestres
        /// </summary>
        /// <returns>Liste de Semester</returns>
        Task<Semester[]> GetAllSemesters();
    }
}
