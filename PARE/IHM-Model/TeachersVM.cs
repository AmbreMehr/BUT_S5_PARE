using Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
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
        
        /// <summary>
        /// Recupère la liste des teachers VM
        /// </summary>
        public List<TeacherVM> Teachers
        {
            get { return model; }
        }

        /// <summary>
        /// Initialise la classe avec la liste des teachers VM à vide
        /// </summary>
        public TeachersVM()
        {
            this.model = new List<TeacherVM>();
        }
    }
}
