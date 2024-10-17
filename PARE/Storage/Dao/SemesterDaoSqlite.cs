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
    /// Gère les données des semestres
    /// </summary>
    /// <author>Clotilde MALO</author>
    public class SemesterDaoSqlite : ISemesterDao
    {
        private DatabaseSqlite db;

        /// <summary>
        /// Constructeur de base pour initialiser la connexion
        /// </summary>
        public SemesterDaoSqlite()
        {
            this.db = new DatabaseSqlite();
        }
        public Semester[] ListAll()
        {
            throw new NotImplementedException();
        }
    }
}
