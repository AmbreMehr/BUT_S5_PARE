using Microsoft.AspNetCore.Mvc;
using Model;
using Storage;
using Storage.InterfaceDAO;

namespace API.Services
{
    public class UserService
    {
        private IUserDao userDao;
        private IRoleDao roleDao;

        public UserService()
        {
            this.userDao = new UserDaoSqlite();
            this.roleDao = new RoleDaoSqlite();
        }

        /// <summary>
        /// Renvoie tous les utilisateurs
        /// </summary>
        /// <returns>Liste de User</returns>
        /// <author>AmbreMehr</author>
        public User[] GetAllUsers()
        {
            return this.userDao.ListAll();
        }

        /// <summary>
        /// Renvoie la liste de rôles, type d'utilisateur
        /// </summary>
        /// <returns>Liste de Role</returns>
        /// <author>AmbreMehr</author>
        public Role[] GetAllRoles()
        {
            IEnumerable<Role> roles = this.roleDao.ListAll();
            return roles.ToArray();
        }

        /// <summary>
        /// Renvoie la liste d'utilisateurs ayant le rôle passé en paramètre
        /// </summary>
        /// <param name="roleId">id du rôle</param>
        /// <returns>Tableau de User</returns>
        /// <author>AmbreMehr</author>
        public User[] GetAllByRole(int roleId)
        {
            return userDao.ListAllByRole(roleId);

        }
    }
}
