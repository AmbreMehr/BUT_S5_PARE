using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Network
{
    /// <author>AmbreMehr</author>
    public interface IUserNetwork
    {
        /// <summary>
        /// Async, renvoie tous les utilisateurs
        /// </summary>
        /// <returns>Liste de User</returns>
        Task<User[]> GetAllUsers();

        /// <summary>
        /// Async, renvoie l'utilisateur de l'Id donné
        /// </summary>
        /// <param name="id">int userId</param>
        /// <returns>User</returns>
        Task<User> GetUserById(int id);

        /// <summary>
        /// Async, met à jour l'utilisateur
        /// </summary>
        /// <param name="user">User</param>
        /// <returns>HTTP Code</returns>
        Task UpdateUser(User user);

        /// <summary>
        /// Async, renvoie la liste des profils types
        /// </summary>
        /// <returns>Liste de TypicalProfile</returns>
        Task<TypicalProfile[]> GetTypicalProfiles();

        /// <summary>
        /// Async, renvoie tous les rôles existants dans l'application
        /// </summary>
        /// <returns>Liste de Role</returns>
        Task<Role[]> GetAllRoles();

        /// <summary>
        /// Async, renvoie tous les utilisateurs d'un rôle
        /// </summary>
        /// <param name="role">Role</param>
        /// <returns>User list</returns>
        Task<User[]> GetUsersByRole(Roles role);
    }
}
