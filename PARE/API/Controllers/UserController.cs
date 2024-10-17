using Microsoft.AspNetCore.Mvc;
using Model;

namespace API.Controllers
{
    /// <summary>
    /// Contrôleur pour les utilisateurs
    /// </summary>
    [ApiController]
    [Route("user")]
    public class UserController : ControllerBase
    {
        /// <summary>
        /// Renvoie tous les utilisateurs
        /// </summary>
        /// <returns>Liste de User</returns>
        [HttpGet("GetAll", Name = "GetAllUsers")]
        public User[] GetAllUsers()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Met à jour l'objet User reçu
        /// </summary>
        /// <param name="user">User utilisateur à mettre à jour</param>
        /// <returns>HTTP Code</returns>
        [HttpPost(Name = "UpdateUser")]
        public IActionResult UpdateUser(User user)
        {
            throw new NotImplementedException();
        }
    }
}
