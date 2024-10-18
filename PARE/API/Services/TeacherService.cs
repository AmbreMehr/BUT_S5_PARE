using Microsoft.AspNetCore.Mvc;
using Model;

namespace API.Services
{
    public class TeacherService
    {
        /// <summary>
        /// Renvoie tous les enseignants qui sont assignés au module
        /// </summary>
        /// <param name="module">Module enseigné</param>
        /// <returns>Liste de Teacher qui enseignent le module</returns>
        public Teacher[] GetTeachersByModule(Module module)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Met à jour l'objet Enseignant reçu
        /// </summary>
        /// <param name="teacher">Teacher à mettre à jour</param>
        /// <returns>boolean</returns>
        public bool UpdateTeacher(Teacher teacher)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Supprime l'objet Enseignant reçu
        /// </summary>
        /// <param name="teacher">Teacher à supprimer</param>
        /// <returns>bool</returns>
        public bool DeleteTeacher(Teacher teacher)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Créer l'objet Enseignant reçu
        /// </summary>
        /// <param name="teacher">Teacher à créer</param>
        /// <returns>boolean</returns>
        public bool CreateTeacher(Teacher teacher)
        {
            throw new NotImplementedException();
        }
    }
}
