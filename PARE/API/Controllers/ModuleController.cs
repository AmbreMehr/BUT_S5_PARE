using Microsoft.AspNetCore.Mvc;
using Model;

namespace API.Controllers
{
    /// <summary>
    /// Contrôleur pour les modules
    /// </summary>
    [ApiController]
    [Route("api/module")]
    public class ModuleController : ControllerBase
    {
        /// <summary>
        /// Met à jour l'objet Module reçu
        /// </summary>
        /// <param name="module">Module à mettre à jour</param>
        /// <returns>HTTP Code</returns>
        [HttpPost("update", Name = "UpdateModule")]
        public IActionResult UpdateModule(Module module)
        {
            throw new NotImplementedException();
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
    }
}
