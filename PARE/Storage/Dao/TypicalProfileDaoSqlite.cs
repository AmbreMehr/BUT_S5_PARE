using Model;
using Storage.InterfaceDAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Storage.Dao
{
    /// <summary>
    /// Gère les données des profils types
    /// </summary>
    /// <author>Clotilde MALO</author>
    public class TypicalProfileDaoSqlite : ITypicalProfileDao
    {
        private DatabaseSqlite db;

        /// <summary>
        /// Constructeur de base pour initialiser la connexion
        /// </summary>
        public TypicalProfileDaoSqlite()
        {
            this.db = new DatabaseSqlite();
        }
        public TypicalProfile[] ListAll()
        {
            throw new NotImplementedException();
        }
    }
}
