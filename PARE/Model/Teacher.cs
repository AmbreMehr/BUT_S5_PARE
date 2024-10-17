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

        /// <summary>
        /// Get et set de l'utilisateur qui est enseignant 
        /// </summary>
        public User User { get => user; set => user = value; }

        /// <summary>
        /// Get et set du module enseigné
        /// </summary>
        public Module Module { get => module; set => module = value; }

        /// <summary>
        /// Get et set du nbre heure TD assigné à ce prof
        /// <exception> Les heures de TD ne peuvent pas être négatives ni supérieur aux heures du module </exception>
        /// </summary>
        public int AssignedTdHours { get => assignedTdHours;
            set 
            {
                if (value < 0)
                {
                    throw new ArgumentException("Les heures de TD ne peuvent pas être négatives");
                }
                else if (value > module.HoursTd)
                {
                    throw new ArgumentException("Les heures de TD assignées ne peuvent pas être supérieures aux heures de TD du module");
                }
                else
                {
                    assignedTdHours = value;
                }
            }
        }

        /// <summary>
        /// Get et set du nbre heure TP assigné à ce prof
        /// <exception> Les heures de TP ne peuvent pas être négatives ni supérieur aux heures du module  </exception>
        /// </summary>
        public int AssignedTpHours { get => assignedTpHours;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Les heures de TP ne peuvent pas être négatives");
                }
                else if (value > module.HoursTp)
                {
                    throw new ArgumentException("Les heures de TP assignées ne peuvent pas être supérieures aux heures de TP du module");
                }
                else
                {
                    assignedTpHours = value;
                }
            }
        }

        /// <summary>
        /// Get et set du nbre heure CM assigné à ce prof
        /// <exception> Les heures de CM ne peuvent pas être négatives ni supérieur aux heures du module </exception>
        /// </summary>
        public int AssignedCmHours { get => assignedCmHours; set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Les heures de CM ne peuvent pas être négatives");
                }
                else if (value > module.HoursCM)
                {
                    throw new ArgumentException("Les heures de CM assignées ne peuvent pas être supérieures aux heures de CM du module");
                }
                else
                {
                    assignedTdHours = value;
                }
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
