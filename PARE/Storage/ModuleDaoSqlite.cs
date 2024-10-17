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
    /// Gère les données des modules
    /// </summary>
    /// <author>Clotilde MALO</author>
    public class ModuleDaoSqlite : IModuleDao
    {
        private DatabaseSqlite db;

        /// <summary>
        /// Constructeur de base pour initialiser la connexion
        /// </summary>
        public ModuleDaoSqlite()
        {
            db = new DatabaseSqlite();
        }

        public Module[] ListAll()
        {
            throw new NotImplementedException();
        }

        public void Update(Module module)
        {
            throw new NotImplementedException();
        }
    }
}
