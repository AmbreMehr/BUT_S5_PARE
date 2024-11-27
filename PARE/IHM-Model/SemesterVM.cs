using Model;
using System.Reflection.Metadata.Ecma335;

namespace IHM_Model
{
    public class SemesterVM : BaseVM
    {
        private Semester model;

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
        /// Initialise la classe en lui passant un semestre
        /// </summary>
        /// <param name="model">semestre</param>
        public SemesterVM(Semester model)
        {
            this.model = model;
        }
    }
}