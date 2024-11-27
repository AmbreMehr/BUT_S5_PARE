using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IHM_Model
{  
    /// <summary>
   /// La classe `TeachersVM` gère les teacher dans l'application PARE.
   /// </summary>
   /// <author>Stéphane BASSET</author>
    public class TeacherVM : BaseVM
    {
        private Teacher model;
        private UserVM user;

        /// <summary>
        /// Récupère l'enseignant
        /// </summary>
        public Teacher Model
        { 
            get { return model;}
        }

        /// <summary>
        /// Récupère l'utilisateurVM associé à l'enseignant
        /// </summary>
        public UserVM User
        {
            get { return user; }
        }

        /// <summary>
        /// Récupère les heures de TD assigné à l'enseignant
        /// </summary>
        public int AssignedTdHours
        {
            get { return model.AssignedTdHours; }
        }

        /// <summary>
        /// Récupère les heures de TP assigné à l'enseignant
        /// </summary>
        public int AssignedTpHours
        {
            get { return model.AssignedTpHours; }
        }

        /// <summary>
        /// Récupère les heures de CM assigné à l'enseignant
        /// </summary>
        public int AssignedCmHours
        {
            get { return model.AssignedCmHours; }
        }

        /// <summary>
        /// Met à jour un teacher.
        /// </summary>
        public async Task UpdateTeacher()
        {
            
        }

        /// <summary>
        /// Suprime un teacher.
        /// </summary>
        public async Task DeleteTeacher()
        {
            
        }

        /// <summary>
        /// Créer un teacher.
        /// </summary>
        public async Task CreateTeacher()
        {   
            
        }

        /// <summary>
        /// Initialise la classe en lui passant un enseignant (teacher)
        /// </summary>
        /// <param name="model"></param>
        public TeacherVM(Teacher model)
        {
            this.model = model;
            this.user =  new UserVM(model.User);
        }

        /// <summary>
        /// Initialise le teacherVM en le laissant vide
        /// </summary>
        public TeacherVM()
        {

        }
    }
}
