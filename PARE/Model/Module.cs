using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    /// <summary>
    /// Classe qui représente la ressource (=module) 
    /// <author>Clotilde MALO</author>
    /// </summary>
    public class Module
    {
        private Semester semester;
        private User supervisor;
        private int id;
        private string name;
        private int hoursTd;
        private int hoursTp;
        private int hoursCM;
        private int weekBegin;
        private int weekEnd;

        /// <summary>
        /// Get et set du semestre dans lequel le module intervient
        /// </summary>
        public Semester Semester { get => semester; set => semester = value; }

        /// <summary>
        /// Get et set de l'utilisateur qui est le superviseur du module
        /// </summary>
        public User Supervisor { get => supervisor; set => supervisor = value; }

        /// <summary>
        /// Get et set de l'id du module
        /// </summary>
        public int Id { get => id; set => id = value; }

        /// <summary>
        /// Get et set du nom du module
        /// </summary>
        public string Name { get => name; set => name = value; }


        /// <summary>
        /// Get et set du nbre d'heures de TD
        /// </summary>
        public int HoursTd
        {
            get => hoursTd;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Les nombre d'heures de TD ne peuvent pas être négatives");
                }
                else
                {
                    hoursTd = value;
                }

            }
        }
        /// <summary>
        /// Get et set du nbre d'heures de TP
        /// </summary>
        public int HoursTp
        {
            get => hoursTp;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Les nombre d'heures de TP ne peuvent pas être négatives");
                }
                else
                {
                    hoursTp = value;
                }
            }
        }

        /// <summary>
        /// Get et set du nbre d'heures de CM
        /// </summary>
        public int HoursCM
        {
            get => hoursCM;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Les nombre d'heures de CM ne peuvent pas être négatives");
                }
                else
                {
                    hoursCM = value;
                }
            }
        }
        /// <summary>
        /// Get et set de la semaine de début
        /// </summary>
        public int WeekBegin {
            get => weekBegin;
            set
            {
                weekBegin = value;
            }
        }

        /// <summary>
        /// Get et set de la semaine de fin
        /// </summary>
        public int WeekEnd
        {
            get => weekEnd;
            set
            {
                weekEnd = value;
            }
        }
        /// <summary>
        /// Constructeur de module avec tous les paramètres sauf supervisor
        /// </summary>
        /// <param name="semester">semestre dans lequel le module intervient</param>
        /// <param name="id">id module</param>
        /// <param name="name">nom module</param>
        /// <param name="hoursTd">nbre heure de TD</param>
        /// <param name="hoursTp">nbre heure TP</param>
        /// <param name="hoursCM">nbre heure CM</param>
        /// <param name="weekBegin">numéro semaine début</param>
        /// <param name="weekEnd">numéro semaine de fin</param>
        public Module(Semester semester, User supervisor, int id, string name, int hoursTd, int hoursTp, int hoursCM, int weekBegin, int weekEnd)
        {
            this.semester = semester;
            this.supervisor = supervisor;
            this.id = id;
            this.name = name;
            this.hoursTd = hoursTd;
            this.hoursTp = hoursTp;
            this.hoursCM = hoursCM;
            this.weekBegin = weekBegin;
            this.weekEnd = weekEnd;
        }

        /// <summary>
        /// Constructeur de module avec seulement le semestre concernéé
        /// </summary>
        public Module(Semester semester)
        {
            this.semester = semester;
        }

        /// <summary>
        /// Constructeur vide de module
        /// </summary>
        public Module()
        {

        }

    }
}
