using Microsoft.Data.Sqlite;
using Model;
using Storage.InterfaceDAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Storage.DAO
{
    /// <summary>
    /// Gère les données des utilisteurs
    /// </summary>
    /// <author>Clotilde MALO</author>
    public class UserDaoSqlite : IUserDao
    {
        private DatabaseSqlite db;

        /// <summary>
        /// Constructeur de base pour initialiser la connexion
        /// </summary>
        public UserDaoSqlite()
        {
            this.db = new DatabaseSqlite();
        }

        public User[] ListAll()
        {
            throw new NotImplementedException();

        }

        public User Read(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(User user)
        {
            throw new NotImplementedException();
        }
    }
}
