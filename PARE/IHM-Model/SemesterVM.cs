using IHM_Model.Exceptions;
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
        /// Récupère la semaine de début
        /// </summary>
        public int WeekBegin
        {
            get => model.SemesterWeekBegin;
        }

        /// <summary>
        /// Récupère la semaine de fin
        /// </summary>
        public int WeekEnd
        {
            get => model.SemesterWeekEnd;
        }

        /// <summary>
        /// Calcule le nombre de semaines dans un semestre en fonction de la semaine de début et de fin
        /// </summary>
        public int NbWeek
        {
            get => WeekEnd - WeekBegin +1;
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
