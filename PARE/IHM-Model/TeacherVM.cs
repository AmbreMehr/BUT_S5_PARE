﻿using Model;
using Network;
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

        private ITeacherNetwork teacherNetwork;

        private bool isInStorage;

        /// <summary>
        /// Récupère l'enseignant
        /// </summary>
        public Teacher Model
        { 
            get { return model;}
        }

        public ModuleVM Module
        {
            get
            {
                return new ModuleVM(model.Module);
            }
            set
            {
                model.Module = value.Model;
                NotifyChange();
            }
        }

        /// <summary>
        /// Récupère l'utilisateurVM associé à l'enseignant
        /// </summary>
        public UserVM User
        {
            get { return new UserVM(model.User); }
            set
            {
                model.User = value.Model;
                NotifyChange();
            }
        }

        /// <summary>
        /// Get et set qui indique si le teacherVM est dans la BDD
        /// </summary>
        public bool IsInStorage
        {
            get { return isInStorage; }
            set { isInStorage = value; }
        }

        /// <summary>
        /// Récupère les heures de TD assigné à l'enseignant
        /// </summary>
        public int AssignedTdHours
        {
            get { return model.AssignedTdHours; }
            set
            {
                if (model.AssignedTdHours != value)
                {
                    model.AssignedTdHours = value;
                    NotifyChange();
                }
            }
        }

        /// <summary>
        /// Récupère les heures de TP assigné à l'enseignant
        /// </summary>
        public int AssignedTpHours
        {
            get { return model.AssignedTpHours; }
            set
            {
                if (model.AssignedTpHours != value)
                {
                    model.AssignedTpHours = value;
                    NotifyChange();
                }
            }
        }

        /// <summary>
        /// Récupère les heures de CM assigné à l'enseignant
        /// </summary>
        public int AssignedCmHours
        {
            get { return model.AssignedCmHours; }
            set
            {
                if (model.AssignedCmHours != value)
                {
                    model.AssignedCmHours = value;
                    NotifyChange();
                }
            }
        }

        /// <summary>
        /// Met à jour un teacher.
        /// </summary>
        public async Task UpdateTeacher()
        {
            await teacherNetwork.UpdateTeacher(model);

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
            await teacherNetwork.CreateTeacher(model);
        }

        /// <summary>
        /// Initialise la classe en lui passant un enseignant (teacher)
        /// </summary>
        /// <param name="model"></param>
        public TeacherVM(Teacher model)
        {
            this.model = model;
            this.teacherNetwork = new TeacherNetwork();

        }

        /// <summary>
        /// Initialise le teacherVM en le laissant vide et initialise le teacherNetwork
        /// </summary>
        public TeacherVM()
        {
            this.model = new Teacher();
            this.teacherNetwork = new TeacherNetwork();
        }
    }
}
