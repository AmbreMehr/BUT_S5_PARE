using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore.Sqlite;
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
            db = new DatabaseSqlite();
        }


        public User Reader2User(SqliteDataReader reader)
        {
            User user = new User();
            user.Id = Convert.ToInt32(reader["idUser"]);
            user.FirstName = reader["firstname"].ToString();
            user.LastName = reader["lastname"].ToString();
            user.RealHours = (reader["realHours"] != DBNull.Value) ? Convert.ToInt32(reader["realHours"]) : 0;
            user.Profil = Reader2TypicalProfile(reader);
            RoleDaoSqlite roleDao = new RoleDaoSqlite();
            Role role = roleDao.Reader2Role(reader);
            user.Roles.Add(role);
            return user;
        }

        public TypicalProfile Reader2TypicalProfile(SqliteDataReader reader)
        {
            TypicalProfile typicalProfile = new TypicalProfile();
            typicalProfile.Id = (reader["idTypicalProfile"] != DBNull.Value) ? Convert.ToInt32(reader["idTypicalProfile"]) : null;
            typicalProfile.Name = (reader["nameTypicalProfile"] != DBNull.Value) ? (reader["nameTypicalProfile"]).ToString() : null;
            typicalProfile.ServiceHours = (reader["serviceHours"] != DBNull.Value) ? Convert.ToInt32(reader["serviceHours"]) : 0;
            return typicalProfile;
        }



        public User[] ListAll()
        {

            // permet d'associer l'id et l'utilisateur : utile quand l'utilisateur a plusieurs rôles
            Dictionary<int, User> userDictionary = new Dictionary<int, User>();
            db.Connection.Open();
            var cmd = db.Connection.CreateCommand();
            cmd.CommandText = "SELECT " +
                               "u.idUser" +
                               ", firstname" +
                               ", lastname" +
                               ", realHours" +
                               ", u.idTypicalProfile" +
                               ", nameTypicalProfile" +
                               ", serviceHours" +
                               ", ru.idRole" +
                               ", roleName" +
                               " FROM Users AS u" +
                               " LEFT JOIN TypicalProfile AS p ON u.idTypicalProfile = p.idTypicalProfile" +
                               " LEFT JOIN RoleOfUser AS ru ON u.idUser = ru.idUser" +
                               " LEFT JOIN Role AS r ON ru.idRole = r.idRole;";
            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    int userId = Convert.ToInt32(reader["idUser"]);

                    // Si utilisateur n'existe pas alors le créer
                    if (!userDictionary.TryGetValue(userId, out User user))
                    {
                        user = Reader2User(reader);
                        userDictionary[userId] = user;
                    }

                    // si encore un rôle ajout du rôle
                    if (reader["idRole"] != DBNull.Value)
                    {
                        RoleDaoSqlite roleDao = new RoleDaoSqlite();
                        Role role = roleDao.Reader2Role(reader);
                        if (!user.Roles.Any(r => r.Id == role.Id))
                        {
                            user.Roles.Add(role);
                        }
                    }
                }
            }
            db.Connection.Close();
            return userDictionary.Values.ToArray();

        }

        public User Read(int id)
        {
            User user = new User();
            db.Connection.Open();
            var cmd = db.Connection.CreateCommand();
            cmd.CommandText = "SELECT " +
                               "u.idUser" +
                               ", firstname" +
                               ", lastname" +
                               ", realHours" +
                               ", u.idTypicalProfile" +
                               ", nameTypicalProfile" +
                               ", serviceHours" +
                               ", ru.idRole" +
                               ", roleName" +
                               " FROM Users AS u" +
                               " LEFT JOIN TypicalProfile AS p ON u.idTypicalProfile = p.idTypicalProfile" +
                               " LEFT JOIN RoleOfUser AS ru ON u.idUser = ru.idUser" +
                               " LEFT JOIN Role AS r ON ru.idRole = r.idRole" +
                               " WHERE u.idUser = @idUser";
            cmd.Parameters.AddWithValue("@idUser", id);
            using (var reader = cmd.ExecuteReader())
            {
                reader.Read();
                user = Reader2User(reader);

            }
            db.Connection.Close();
            return user;
        }

        public void Update(User user)
        {
            throw new NotImplementedException();
        }

        
    }
}
