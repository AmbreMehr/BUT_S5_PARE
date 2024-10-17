using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Storage.InterfaceDAO
{
    /// <summary>
    /// Interface qui permet de gérer les données de l'utilisateur
    /// </summary>
    /// <author>Clotilde MALO</author>
    public interface IUserDao
    {
        /// <summary>
        /// Renvoi un utilisateur à partir de l'id
        /// </summary>
        /// <param name="id">id de l'utilisateur</param>
        /// <returns>utilisateur correspondant à l'id</returns>
        public User Read(int id);

        /// <summary>
        /// Modifie l'utilisateur
        /// </summary>
        /// <param name="user">utilisateur à modifié</param>
        public void Update(User user);

        /// <summary>
        /// Renvoi tous les utilisateurs
        /// </summary>
        /// <returns>utilisateurs</returns>
        public User[] ListAll();
    }
}
