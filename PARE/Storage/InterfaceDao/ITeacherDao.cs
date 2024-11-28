﻿using Microsoft.Data.Sqlite;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Storage.InterfaceDAO
{
    /// <summary>
    /// Interface qui permet de gérer les données des enseignants
    /// </summary>
    /// <author> Clotilde MALO</author>
    public interface ITeacherDao
    {
        /// <summary>
        /// Renvoi tous les enseignants pour un module
        /// </summary>
        /// <param name="idModule">id du module</param>
        /// <returns>enseignants qui est assigné au module</returns>
        public Teacher[] ListForModule(string idModule);

        /// <summary>
        /// Met à jour l'enseignant
        /// </summary>
        /// <param name="teacher">enseignant mis à jour</param>
        public void Update(Teacher teacher);

        /// <summary>
        /// Converti le reader en enseignant
        /// </summary>
        /// <param name="reader">reader utilisé</param>
        /// <returns>enseignant converti</returns>
        public Teacher Reader2Teacher(SqliteDataReader reader);

        /// <summary>
        /// Supprime un enseignant d'un module
        /// </summary>
        /// <param name="teacher">enseignant à supprimer d'un module</param>
        public void Delete(Teacher teacher);
    }
}
