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
        private Teacher _model;
        public Teacher Model
            { 
            get { return _model;}
            set { 
                _model = value;
                NotifyChange("Teacher");
            }
        }

        /// <summary>
        /// Update un teacher.
        /// </summary>
        /// <author>Stéphane BASSET</author>
        public void UpdateTeacher(Teacher teacherModify)
        {
            _model = teacherModify;
        }

        /// <summary>
        /// Suprime un teacher.
        /// </summary>
        /// <author>Stéphane BASSET</author>
        public void DeleteTeacher(Teacher teacherDelete)
        {
            _model = teacherDelete;
        }

        /// <summary>
        /// Créer un teacher.
        /// </summary>
        /// <author>Stéphane BASSET</author>
        public void CreateTeacher( Teacher teacherToCreate)
        {   
            _model = teacherToCreate;
        }
    }
}
