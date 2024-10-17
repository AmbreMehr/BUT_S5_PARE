using Microsoft.Data.Sqlite;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Storage.InterfaceDAO
{
    /// <summary>
    /// Interface qui permet de gérer les données des semestres
    /// </summary>
    /// <author>Clotilde MALO</author>
    public interface ISemesterDao
    {
        /// <summary>
        /// Renvoi tous les semestres
        /// </summary>
        /// <returns>semestres</returns>
        public Semester[] ListAll();

        /// <summary>
        /// Convertit un reader en semestre
        /// </summary>
        /// <param name="reader">reader associé au semestre</param>
        /// <returns>semestre converti</returns>
        public Semester Reader2Semester(SqliteDataReader reader);
    }
}
