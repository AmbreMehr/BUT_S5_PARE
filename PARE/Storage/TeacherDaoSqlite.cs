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
    /// Gère les données des enseignants d'un module
    /// </summary>
    /// <author>Clotilde MALO</author>
    public class TeacherDaoSqlite : ITeacherDao
    {
        private DatabaseSqlite db;

        /// <summary>
        /// Constructeur de base pour initialiser la connexion
        /// </summary>
        public TeacherDaoSqlite()
        {
            db = new DatabaseSqlite();
        }
        public Teacher[] ListForModule(Module module)
        {
            throw new NotImplementedException();
        }

        public void Update(Teacher teacher)
        {
            throw new NotImplementedException();
        }
    }
}
