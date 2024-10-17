using Microsoft.AspNetCore.Mvc;
using Model;

namespace API.Controllers
{
    /// <summary>
    /// Contrôleur pour les enseignants
    /// </summary>
    [ApiController]
    [Route("teacher")]
    public class TeacherController : ControllerBase
    {
        /// <summary>
        /// Renvoie tous les enseignants qui sont assignés au module
        /// </summary>
        /// <param name="module">Module enseigné</param>
        /// <returns>Liste de Teacher qui enseignent le module</returns>
        [HttpGet("GetTeachersByModule", Name = "GetTeachersByModule")]
        public Teacher[] GetTeachersByModule(Module module)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Met à jour l'objet Enseignant reçu
        /// </summary>
        /// <param name="teacher">Teacher à mettre à jour</param>
        /// <returns>HTTP Code</returns>
        [HttpPost(Name = "UpdateTeacher")]
        public IActionResult UpdateTeacher(Teacher teacher)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Supprime l'objet Enseignant reçu
        /// </summary>
        /// <param name="teacher">Teacher à supprimer</param>
        /// <returns>HTTP Code</returns>
        [HttpPost("delete", Name = "DeleteTeacher")]
        public IActionResult DeleteTeacher(Teacher teacher) 
        { 
            throw new NotImplementedException(); 
        }

        /// <summary>
        /// Créer l'objet Enseignant reçu
        /// </summary>
        /// <param name="teacher">Teacher à créer</param>
        /// <returns>HTTP Code</returns>
        [HttpPost("create", Name = "CreateTeacher")]
        public IActionResult CreateTeacher(Teacher teacher)
        {
            throw new NotImplementedException();
        }
    }
}
