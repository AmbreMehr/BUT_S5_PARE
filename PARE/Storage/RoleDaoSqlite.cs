using Model;
using Storage.InterfaceDAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Storage
{
    /// <summary>
    /// Gère les données des rôles d'un module
    /// </summary>
    /// <author>Clotilde MALO</author>
    public class RoleDaoSqlite : IRoleDao
    {
        private DatabaseSqlite db;

        /// <summary>
        /// Constructeur de base pour initialiser la connexion
        /// </summary>
        public RoleDaoSqlite()
        {
            db = new DatabaseSqlite();
        }
        public Role[] ListAll()
        {
            throw new NotImplementedException();
        }
    }
}
