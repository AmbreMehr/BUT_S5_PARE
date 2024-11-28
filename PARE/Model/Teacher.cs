using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    /// <summary>
    /// Classe qui représente l'enseignant (utilisateur) d'un module spécifique
    /// </summary>
    /// <author>ClotildeMALO</author>
    public class Teacher
    {
        private User user;
        private Module module;
        private int assignedTdHours;
        private int assignedTpHours;
        private int assignedCmHours;
        private int id;

        /// <summary>
        /// Get et set de l'utilisateur qui est enseignant 
        /// </summary>
        public User User { get => user; set => user = value; }

        /// <summary>
        /// Get et set du module enseigné
        /// </summary>
        public Module Module { get => module; set => module = value; }

        /// <summary>
        /// Get et set de l'id de l'enseignant
        /// </summary>
        public int Id
        {
            get => id;
            set
            {
                id = value;
            }
        }

        /// <summary>
        /// Get et set du nbre heure TD assigné à ce prof
        /// </summary>
        public int AssignedTdHours { get => assignedTdHours;
            set 
            {
                assignedTdHours = value;
            }
        }

        /// <summary>
        /// Get et set du nbre heure TP assigné à ce prof
        /// </summary>
        public int AssignedTpHours { get => assignedTpHours;
            set
            {
                assignedTpHours = value;
            }
        }

        /// <summary>
        /// Get et set du nbre heure CM assigné à ce prof
        /// </summary>
        public int AssignedCmHours { get => assignedCmHours; set
            {
                assignedCmHours = value;
                
            }
        }

        /// <summary>
        /// Constructeur de l'enseignant avec tous les paramètres
        /// </summary>
        /// <param name="user">utilisateur qui enseigne</param>
        /// <param name="module">module enseigné</param>
        /// <param name="assignedTdHours">nbre heure TD assigné à ce prof</param>
        /// <param name="assignedTpHours">nbre heure TP assigné à ce prof</param>
        /// <param name="assignedCmHours">nbre heure CM assigné à ce prof</param>
        public Teacher(User user, Module module, int assignedTdHours, int assignedTpHours, int assignedCmHours)
        {
            this.user = user;
            this.module = module;
            this.assignedTdHours = assignedTdHours;
            this.assignedTpHours = assignedTpHours;
            this.assignedCmHours = assignedCmHours;
        }

        /// <summary>
        /// Constructeur vide de l'enseignant
        /// </summary>
        public Teacher()
        {

        }
    }
}
