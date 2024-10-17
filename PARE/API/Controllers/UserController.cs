﻿using Microsoft.AspNetCore.Mvc;
using Model;

namespace API.Controllers
{
    /// <summary>
    /// Contrôleur pour les utilisateurs
    /// </summary>
    [ApiController]
    [Route("api/user")]
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
    }
}
