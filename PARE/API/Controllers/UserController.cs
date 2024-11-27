using Microsoft.AspNetCore.Mvc;
using Model;

namespace API.Controllers
{
    /// <summary>
    /// Contrôleur pour les utilisateurs
    /// </summary>
    [ApiController]
    [Route("api/user")]
    public class UserController : MyControllerBase
    {
        /// <summary>
        /// Renvoie tous les utilisateurs
        /// </summary>
        /// <returns>Liste de User</returns>
        /// <author>AmbreMehr</author>
        [HttpGet("GetAll", Name = "GetAllUsers")]
        public User[] GetAllUsers()
        {
            IEnumerable<User> users = this.UserService.GetAllUsers();
            return users.ToArray();
        }

        /// <summary>
        /// Renvoie l'utilisateur lié à un ID
        /// </summary>
        /// <param name="id">int id de l'utilisateur</param>
        /// <returns>User</returns>
        [HttpGet("GetById", Name = "GetUserById")]
        public User GetUserById(int id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Met à jour l'objet User reçu
        /// </summary>
        /// <param name="user">User utilisateur à mettre à jour</param>
        /// <returns>HTTP Code</returns>
        [HttpPost("update", Name = "UpdateUser")]
        public IActionResult UpdateUser(User user)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Renvoie la liste de profils typiques
        /// </summary>
        /// <returns>Liste de TypicalProfile</returns>
        [HttpGet("GetAllTypicalProfiles", Name = "GetAllTypicalProfiles")]
        public TypicalProfile[] GetTypicalProfiles()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Renvoie la liste de rôles, type d'utilisateur
        /// </summary>
        /// <returns>Liste de Role</returns>
        /// <author>AmbreMehr</author>
        [HttpGet("GetAllRoles", Name = "GetAllRoles")]
        public Role[] GetAllRoles()
        {
            IEnumerable<Role> roles = this.UserService.GetAllRoles();
            return roles.ToArray();
        }

        /// <summary>
        /// Renvoie la liste d'utilisateurs ayant le rôle passé en paramètre
        /// </summary>
        /// <param name="roleId">id du rôle</param>
        /// <returns>Tableau de User</returns>
        /// <author>AmbreMehr</author>
        [HttpGet("GetAllByRole", Name = "GetAllByRole")]
        public User[] GetAllByRole(int roleId)
        {
            IEnumerable<User> users = UserService.GetAllByRole(roleId);
            return users.ToArray();
        }
    }
}
