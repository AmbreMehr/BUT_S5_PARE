using IHM_Model.Exceptions;
using Model;
using Network;
using System;
using System.Collections.Generic;
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

        /// <summary>
        /// Récupère le moduleVM associé à l'enseignant
        /// </summary>
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
            try
            {
                // Verif règles métier
                if (this.AssignedCmHours > this.Module.HoursCM 
                        || this.AssignedTdHours > this.Module.HoursTd
                        || this.AssignedTpHours > this.Module.HoursTp)
                {
                    throw new ExceptionHourProgram(Ressource.StringRes.HourProgram);
                }

                if (this.AssignedTpHours < 0 ||
                    this.AssignedTdHours < 0 ||
                    this.AssignedCmHours < 0)
                {
                    throw new ExceptionHourNegative(Ressource.StringRes.HourNegative);
                }
                
                await teacherNetwork.UpdateTeacher(model);

                
            }
            catch (Exception ex)
            {
                // Gérer les autres erreurs
                throw new Exception(Ressource.StringRes.ErrorMAJTeacher, ex);
            }

        }

        /// <summary>
        /// Suprime un teacher.
        /// </summary>
        public async Task DeleteTeacher()
        {
            await teacherNetwork.DeleteTeacher(model);

        }

        /// <summary>
        /// Créer un teacher.
        /// </summary>
        public async Task CreateTeacher()
        {
            // Verif règles métier
            if (this.AssignedCmHours > this.Module.HoursCM
                    || this.AssignedTdHours > this.Module.HoursTd
                    || this.AssignedTpHours > this.Module.HoursTp)
            {
                throw new ExceptionHourProgram(Ressource.StringRes.HourProgram);
            }

            if (this.AssignedTpHours < 0 ||
                this.AssignedTdHours < 0 ||
                this.AssignedCmHours < 0)
            {
                throw new ExceptionHourNegative(Ressource.StringRes.HourNegative);
            }
            try
            {
                await teacherNetwork.CreateTeacher(model);

            }
            catch (Exception ex)
            {
                // Gérer les autres erreurs
                throw new Exception(Ressource.StringRes.ErrorAddTeacher, ex);
            }
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
