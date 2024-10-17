using Model;

namespace API.Services
{
    public class ModuleService
    {
        /// <summary>
        /// Renvoie le nombre d'heures suivies par les étudiants pour une semaine donnée
        /// </summary>
        /// <param name="week">int numéro de semaine selon le calendrier civil</param>
        /// <returns>int nombre d'heures suivies par les étudiants</returns>
        public int GetHoursForWeek(int week)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Renvoie tous les enseignants 
        /// </summary>
        /// <param name="module">Module</param>
        /// <returns>Liste de Teacher qui enseignent le module</returns>
        public Teacher[] GetTeachersForModule(Module module)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Renvoie le module avec son ID
        /// </summary>
        /// <param name="id">int ID du Module</param>
        /// <returns>Module</returns>
        public Module GetModuleById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
