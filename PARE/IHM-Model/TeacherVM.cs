﻿using Model;
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

        public Teacher Model
        { 
            get { return model;}
        }

        /// <summary>
        /// Update un teacher.
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

        public TeacherVM(Teacher model)
        {
            this.model = model;
        }
    }
}
