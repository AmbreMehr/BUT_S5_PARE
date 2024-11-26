using Model;
using Network;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IHM_Model
{
    /// <summary>
    /// Classe qui s'occupe de la liaison entre la vue et le modèle pour les semestres
    /// </summary>
    /// <author>Clotilde MALO</author>
    public class SemestersVM : BaseVM
    {
        private List<SemesterVM> models;
        private ISemesterNetwork semesterNetwork;
        private SemesterVM? selectedSemester;

        /// <summary>
        /// Get du tableau de semestres
        /// </summary>
        public SemesterVM[] Semesters
        {
            get { return models.ToArray(); }
        }

        /// <summary>
        /// Get et set du semestre sélectionné
        /// </summary>
        public SemesterVM? SelectedSemester
        {
            get { return selectedSemester; }
            set
            {
                selectedSemester = value;
                NotifyChange("SelectedSemester");
            }
        }


        /// <summary>
        /// Constructeur initialisant le tableau de semestres.
        /// </summary>
        public SemestersVM()
        {
            semesterNetwork = new SemesterNetwork();
            models = new List<SemesterVM>();
            LoadSemesters();
        }

        /// <summary>
        /// Récupère tous les semestres.
        /// </summary>
        private async void LoadSemesters()
        {
            Semester[] semesters = await semesterNetwork.GetAllSemesters();
            foreach (Semester semester in semesters)
            {
                models.Add(new SemesterVM(semester));
            }
            // initialisation du 1e element en selected
            if (semesters != null && models.Count() > 0)
            {
                SelectedSemester = models.First();
            }
        }
    }
}
