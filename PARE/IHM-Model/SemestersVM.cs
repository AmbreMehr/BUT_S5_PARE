using Model;
using Network;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        private ObservableCollection<SemesterVM> models;
        private ISemesterNetwork semesterNetwork;
        private SemesterVM? selectedSemester;

        /// <summary>
        /// Evenement quand une erreur se produit
        /// </summary>
        public event EventHandler<string> ErrorOccurred;

        /// <summary>
        /// Get du tableau de semestres
        /// </summary>
        public ObservableCollection<SemesterVM> Semesters
        {
            get { return models; }
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
            models = new ObservableCollection<SemesterVM>();
            LoadSemesters();
        }

        /// <summary>
        /// Récupère tous les semestres.
        /// </summary>
        private async void LoadSemesters()
        {
            try
            {
                Semester[] semesters = await semesterNetwork.GetAllSemesters();
                foreach (Semester semester in semesters)
                {
                    models.Add(new SemesterVM(semester, this.semesterNetwork));
                }
                // initialisation du 1e element en selected
                if (semesters != null && models.Count() > 0)
                {
                    SelectedSemester = models.First();
                }
            }
            catch (Exception ex)
            {
                ErrorOccurred?.Invoke(this, ex.Message);
            }
        }
    }
}
