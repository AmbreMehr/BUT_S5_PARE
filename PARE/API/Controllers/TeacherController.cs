using Microsoft.AspNetCore.Mvc;

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
        public Object[] GetTeachersByModule(Object module)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Met à jour l'objet Enseignant reçu
        /// </summary>
        /// <param name="teacher">Teacher à mettre à jour</param>
        /// <returns>HTTP Code</returns>
        [HttpPost(Name = "UpdateTeacher")]
        public IActionResult UpdateTeacher(Object teacher)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Supprime l'objet Enseignant reçu
        /// </summary>
        /// <param name="teacher">Teacher à supprimer</param>
        /// <returns>HTTP Code</returns>
        [HttpPost("delete", Name = "DeleteTeacher")]
        public IActionResult DeleteTeacher(Object teacher) 
        { 
            throw new NotImplementedException(); 
        }

        /// <summary>
        /// Créer l'objet Enseignant reçu
        /// </summary>
        /// <param name="teacher">Teacher à créer</param>
        /// <returns>HTTP Code</returns>
        [HttpPost("create", Name = "CreateTeacher")]
        public IActionResult CreateTeacher(Object teacher)
        {
            throw new NotImplementedException();
        }
    }
}
