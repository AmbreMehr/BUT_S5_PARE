using Microsoft.AspNetCore.Mvc;
using Model;

namespace API.Controllers
{
    /// <summary>
    /// Contrôleur pour les enseignants
    /// </summary>
    [ApiController]
    [Route("api/teacher")]
    public class TeacherController : MyControllerBase
    {
        /// <summary>
        /// Renvoie tous les enseignants qui sont assignés au module
        /// <author>Clotilde MALO</author>
        /// </summary>
        /// <param name="idModule">id du module enseigné</param>
        /// <returns>Liste de Teacher qui enseignent le module</returns>
        [HttpGet("GetTeachersByModule", Name = "GetTeachersByModule")]
        public Teacher[] GetTeachersByModule(int idModule)
        {
            Teacher[] teachers = this.TeacherService.GetTeachersByModule(idModule);
            return teachers;
        }

        /// <summary>
        /// Met à jour l'objet Enseignant reçu
        /// </summary>
        /// <param name="teacher">Teacher à mettre à jour</param>
        /// <returns>HTTP Code</returns>
        [HttpPost("update", Name = "UpdateTeacher")]
        public IActionResult UpdateTeacher(Teacher teacher)
        {
            this.TeacherService.UpdateTeacher(teacher);
            return Ok();
        }

        /// <summary>
        /// Supprime l'objet Enseignant reçu
        /// </summary>
        /// <param name="teacher">Teacher à supprimer</param>
        /// <returns>HTTP Code</returns>
        [HttpPost("delete", Name = "DeleteTeacher")]
        public IActionResult DeleteTeacher(Teacher teacher) 
        {
            this.TeacherService.DeleteTeacher(teacher);
            return Ok();
        }

        /// <summary>
        /// Créer l'objet Enseignant reçu
        /// </summary>
        /// <param name="teacher">Teacher à créer</param>
        /// <returns>HTTP Code</returns>
        [HttpPost("create", Name = "CreateTeacher")]
        public IActionResult CreateTeacher(Teacher teacher)
        {
            this.TeacherService.CreateTeacher(teacher);
            return Ok();
        }
    }
}
