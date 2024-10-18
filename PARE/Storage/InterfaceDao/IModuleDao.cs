using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;
using Model;

namespace Storage.InterfaceDAO
{
    /// <summary>
    /// Interface qui permet de gérer les données des modules 
    /// </summary>
    /// <author>Clotilde MALO</author>
    public interface IModuleDao
    {
        /// <summary>
        /// Met à jour le module
        /// </summary>
        /// <param name="module">module mis à jour</param>
        public void Update(Module module);

        /// <summary>
        /// Renvoi tous les modules
        /// </summary>
        /// <returns>modules</returns>
        public Module[] ListAll();

        /// <summary>
        /// Recupere tous les modules d'un semestre particulier
        /// </summary>
        /// <param name="semesterId">id du semestre voulu</param>
        /// <returns>modules</returns>
        public Module[] GetAllBySemester(int semesterId);

        /// <summary>
        /// Convertit un reader en module
        /// </summary>
        /// <param name="reader">reader contenant module</param>
        /// <returns>moduleconverti</returns>
        public Module Reader2Module(SqliteDataReader reader);

    }
}
