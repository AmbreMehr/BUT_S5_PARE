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
        /// Renvoie l'utilisateur lié à un ID
        /// </summary>
        /// <param name="id">int id de l'utilisateur</param>
        /// <returns>User</returns>
        public User GetUserById(int id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Renvoie la liste des utilisateurs ayant le role envoyé
        /// </summary>
        /// <param name="role">Role</param>
        /// <returns>User</returns>
        public User[] GetAllByRole(Role role)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Renvoie tous les utilisateurs
        /// </summary>
        /// <returns>Liste de User</returns>
        public User[] GetAllUsers()
        {
            return this.userDao.ListAll();
        }

        /// <summary>
        /// Met à jour l'objet User reçu
        /// </summary>
        /// <param name="user">User utilisateur à mettre à jour</param>
        /// <returns>HTTP Code</returns>
        public IActionResult UpdateUser(User user)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Renvoie la liste de profils typiques
        /// </summary>
        /// <returns>Liste de TypicalProfile</returns>
        public TypicalProfile[] GetTypicalProfiles()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Renvoie la liste de rôles, type d'utilisateur
        /// </summary>
        /// <returns>Liste de Role</returns>
        public Role[] GetAllRoles()
        {
            IEnumerable<Role> roles = this.roleDao.ListAll();
            return roles.ToArray();
        }
    }
}
