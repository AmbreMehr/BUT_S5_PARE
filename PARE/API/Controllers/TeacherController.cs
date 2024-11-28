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
        public Teacher[] GetTeachersByModule(string idModule)
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
            IActionResult result = BadRequest();
            try
            {
                this.TeacherService.UpdateTeacher(teacher);
                result = Ok("L'enseignant a été mis à jour avec succès.");
            }
            catch
            {
                result = NotFound("L'enseignant n'a pas été mis à jour.");
            }
            return result;

        }

        /// <summary>
        /// Supprime l'objet Enseignant reçu
        /// </summary>
        /// <param name="teacher">Teacher à supprimer</param>
        /// <returns>HTTP Code</returns>
        [HttpPost("delete", Name = "DeleteTeacher")]
        public IActionResult DeleteTeacher(Teacher teacher) 
        {
            IActionResult result = BadRequest();
            try
            {
                this.TeacherService.DeleteTeacher(teacher);
                result = Ok("L'enseignant a été supprimé avec succès.");
            }
            catch
            {
                result = NotFound("L'enseignant n'a pas été supprimé.");
            }
            return result;
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
