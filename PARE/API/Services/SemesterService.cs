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
        private IModuleDao moduleDao;

        /// <summary>
        /// Constructeur de la classe, initialise ses dépendances aux DAO
        /// </summary>
        public SemesterService ()
        {
            this.semesterDao = new SemesterDaoSqlite();
            this.moduleDao = new ModuleDaoSqlite();
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

        /// <summary>
        /// Renvoie le nombre d'heures que les étudiants feront par semaine sur un semestre donné
        /// </summary>
        /// <param name="semesterId">semestre pour lequel calculer</param>
        /// <returns>dictionnaire semaine -> heures des étudiants</returns>
        public Dictionary<int, float> GetHoursPerWeekBySemester(int semesterId)
        {
            Module[] modules = this.moduleDao.GetAllBySemester(semesterId);
            return ComputeHoursPerWeek(modules);
        }

        /// <summary>
        /// Renvoie le calcul du nombre d'heures que les étudiants feront par semaine
        /// </summary>
        /// <param name="modules"></param>
        /// <returns></returns>
        private Dictionary<int, float> ComputeHoursPerWeek(Module[] modules)
        {
            Dictionary<int, float> hoursByWeek = new Dictionary<int, float>();
            foreach (Module module in modules)
            {
                int moduleDuration = module.WeekEnd - module.WeekBegin + 1;
                float moduleHours = module.HoursCM + module.HoursTd + module.HoursTp;

                for (int week = module.WeekBegin; week <= module.WeekEnd; week++)
                {
                    if (!hoursByWeek.ContainsKey(week))
                        hoursByWeek[week] = 0;
                    hoursByWeek[week] += moduleHours / moduleDuration;
                }
            }
            return hoursByWeek;
        }
    }
}
