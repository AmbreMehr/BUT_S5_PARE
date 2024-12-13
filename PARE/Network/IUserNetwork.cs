using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Network
{
    /// <summary>
    /// Interface de réseau pour gérer les utilisateurs
    /// </summary>
    public interface IUserNetwork
    {
        /// <summary>
        /// Async, renvoie tous les utilisateurs d'un rôle
        /// </summary>
        /// <param name="role">Role</param>
        /// <returns>User list</returns>
        Task<User[]> GetUsersByRole(Roles role);
    }
}
