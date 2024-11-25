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
    public class SemesterVM : BaseVM
    {
        private Semester[] _models;
        private Semester _selectedSemester;
        private ISemesterNetwork _semesterNetwork;

        /// <summary>
        /// Get et set du tableau de semestres
        /// </summary>
        public Semester[] Semesters
        {
            get { return _models; }
            set
            {
                _models = value;
                NotifyChange("Semesters");
            }
        }

        /// <summary>
        /// Get et set du semestre sélectionné
        /// </summary>
        public Semester SelectedSemester
        {
            get { return _selectedSemester; }
            set
            {
                _selectedSemester = value;
                NotifyChange("SelectedSemester");
            }
        }


        /// <summary>
        /// Constructeur initialisant le tableau de semestres.
        /// </summary>
        public SemesterVM()
        {
            _semesterNetwork = new SemesterNetwork();
            _models = new Semester[0];
            LoadSemesters();
        }

        private async void LoadSemesters()
        {
            Semesters = await GetAllSemesters();
            // initialisation du 1e element en selected
            if (Semesters != null && Semesters.Length > 0)
            {
                SelectedSemester = Semesters[0];
            }
        }

        /// <summary>
        /// Récupère tous les semestres.
        /// </summary>
        /// <returns></returns>
        public async Task<Semester[]> GetAllSemesters()
        {
            
            Semesters = await _semesterNetwork.GetAllSemesters(); 
            return _models; 
        }

    }
}
