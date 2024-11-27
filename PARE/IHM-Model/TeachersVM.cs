using Model;
using Network;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace IHM_Model
{
    /// <summary>
    /// La classe `TeachersVM` gère les teacher dans l'application PARE.
    /// </summary>
    /// <author>Stéphane BASSET</author>
    public class TeachersVM : BaseVM
    {
        private List<TeacherVM> model;
        private ITeacherNetwork teacherNetwork;
        private TeacherVM? selectedTeacher;


        /// <summary>
        /// Recupère la liste des teachers VM
        /// </summary>
        public List<TeacherVM> Teachers
        {
            get { return model; }
        }

        /// <summary>
        /// Get et set de l'enseignant sélectionné
        /// </summary>
        public TeacherVM? SelectedTeacher
        {
            get { return selectedTeacher; }
            set
            {
                selectedTeacher = value;
                NotifyChange("SelectedTeacher");
            }
        }

        /// <summary>
        /// Initialise la classe avec la liste des teachers VM à vide
        /// </summary>
        public TeachersVM()
        {
            this.model = new List<TeacherVM>();
            this.teacherNetwork = new TeacherNetwork();
        }

        /// <summary>
        /// Récupère les professeurs assigné à un module
        /// </summary>
        /// <param name="moduleVM">moduleVM choisi</param>
        /// <returns>liste de teacherVM qui sont assignés à un module</returns>
        public async Task<List<TeacherVM>> GetTeachersByModule(ModuleVM moduleVM)
        {
            Teachers.Clear();
            Teacher[] teachers = await teacherNetwork.GetTeachersByModule(moduleVM.Model);
            foreach (Teacher teacher in teachers)
            {
                TeacherVM teacherVM = new TeacherVM(teacher);
                Teachers.Add(teacherVM);
            }
            return Teachers;
        }
    }
}
