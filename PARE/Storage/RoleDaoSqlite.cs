using Microsoft.Data.Sqlite;
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
            List<Role> roles = new List<Role>();
            db.Connection.Open();
            var cmd = db.Connection.CreateCommand();
            cmd.CommandText = "SELECT" +
                               " idRole" +
                               ", roleName" +
                               " FROM Role;";
            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    roles.Add(Reader2Role(reader));
                }
            }
            db.Connection.Close();

            return roles.ToArray();
        }

        public Role Reader2Role(SqliteDataReader reader)
        {
            Role role = new Role();
            role.Id = Convert.ToInt32(reader["idRole"]);
            role.Name = reader["roleName"].ToString();

            return role;
        }
    }
}
