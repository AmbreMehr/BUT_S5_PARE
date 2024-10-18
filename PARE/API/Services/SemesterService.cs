using Model;
using Storage;
using Storage.InterfaceDAO;

namespace API.Services
{
    /// <summary>
    /// Classe logique de l'API pour les objets Semester
    /// </summary>
    public class SemesterService
    {
        private ISemesterDao semesterDao;

        public SemesterService ()
        {
            this.semesterDao = new SemesterDaoSqlite();
        }

        /// <summary>
        /// Renvoie tous les Semestres
        /// </summary>
        /// <returns>Liste de Semester</returns>
        /// <author>AmbreMehr</author>
        public IEnumerable<Semester> GetAll()
        {
            return this.semesterDao.ListAll();
        }
    }
}
