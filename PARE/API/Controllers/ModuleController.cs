using Microsoft.AspNetCore.Mvc;
using Model;

namespace API.Controllers
{
    /// <summary>
    /// Contrôleur pour les modules
    /// </summary>
    [ApiController]
    [Route("api/module")]
    public class ModuleController : MyControllerBase
    {
        /// <summary>
        /// Met à jour l'objet Module reçu
        /// </summary>
        /// <param name="module">Module à mettre à jour</param>
        /// <returns>HTTP Code</returns>
        [HttpPut("UpdateModule", Name = "UpdateModule")]
        public IActionResult UpdateModule(Module module)
        {
            this.ModuleService.UpdateModule(module);
            return Ok();
        }

        /// <summary>
        /// Renvoie le nombre d'heures suivies par les étudiants pour une semaine donnée
        /// </summary>
        /// <param name="week">int numéro de semaine selon le calendrier civil</param>
        /// <returns>int nombre d'heures suivies par les étudiants</returns>
        [HttpGet("GetHoursByWeek", Name = "GetHoursByWeek")]
        public int GetHoursByWeek (int week)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Renvoie les modules contenus dans un semestre
        /// </summary>
        /// <param name="semester">Semester</param>
        /// <returns>Liste de Module du semestre</returns>
        /// <author>AmbreMehr</author>
        [HttpGet("GetModulesBySemester", Name = "GetModulesBySemester")]
        public Module[] GetModuleBySemester(int semester)
        {
            IEnumerable<Module> module = this.ModuleService.GetModulesForSemester(semester);
            return module.ToArray();
        }

        /// <summary>
        /// Renvoie tous les modules
        /// </summary>
        /// <returns>Liste de Module</returns>
        /// <author>AmbreMehr</author>
        [HttpGet("GetAllModules", Name = "GetAllModules")]
        public Module[] GetAllModules()
        {
            IEnumerable<Module> module = this.ModuleService.GetAllModules();
            return module.ToArray();
        }
    }
}
