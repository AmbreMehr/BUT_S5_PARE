using Model;
using Network;

namespace IHM_Model
{
    public class SemesterVM : BaseVM
    {
        private Semester model;
        private ISemesterNetwork network;

        /// <summary>
        /// Récupère le semestre
        /// </summary>
        public Semester Model
        {
            get => model;
        }

        /// <summary>
        /// Récupère le nom du semestre
        /// </summary>
        public string Name
        {
            get => model.Name;
        }

        /// <summary>
        /// Renvoie le nombre d'heures des étudiants par semaine, sur le semestre
        /// </summary>
        /// <returns>Dictionnaire semaine -> heures des étudiants</returns>
        public async Task<Dictionary<int, float>> GetHoursPerWeek()
        {
            return await this.network.GetStudentsHoursPerWeek(this.Model);
        }

        /// <summary>
        /// Initialise la classe en lui passant un semestre
        /// </summary>
        /// <param name="model">Semestre</param>
        /// <param name="network">SemesterNetwork pour les requêtes</param>
        public SemesterVM(Semester model, ISemesterNetwork network)
        {
            this.model = model;
            this.network = network;
        }
    }
}