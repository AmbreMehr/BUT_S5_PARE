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
    /// Interface qui permet de gérer les données des rôles
    /// </summary>
    /// <author> Clotilde MALO</author>
    public interface IRoleDao
    {
        /// <summary>
        /// Renvoi tous les rôles
        /// </summary>
        /// <returns>rôles</returns>
        public Role[] ListAll();


        /// <summary>
        /// Converti le reader en role
        /// </summary>
        /// <param name="reader">reader utilisé</param>
        /// <returns> rôle converti</returns>
        public Role Reader2Role(SqliteDataReader reader);
    }
}
