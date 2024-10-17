using Model;

namespace API.Services
{
    /// <summary>
    /// Classe logique de l'API pour les objets Semester
    /// </summary>
    public class SemesterService
    {
        /// <summary>
        /// Renvoie tous les Semestres
        /// </summary>
        /// <returns>Liste de Semester</returns>
        public IEnumerable<Semester> GetAll()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Renvoie les modules contenus dans un semestre
        /// </summary>
        /// <param name="semester">Semester semestre qui contient les modules</param>
        /// <returns>Liste de Module</returns>
        public Module[] GetModulesForSemester(Semester semester)
        {
            throw new NotImplementedException();
        }
    }
}
