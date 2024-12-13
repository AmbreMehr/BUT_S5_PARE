using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    /// <summary>
    /// Semestre existant (équivalent à une promotion)
    /// </summary>
    /// <author>Clotilde MALO</author>
    public class Semester
    {
        private int id;
        private string name;
        private int nbTpGroups;
        private int semesterWeekBegin;
        private int semesterWeekEnd;


        /// <summary>
        /// Récupère et remplace l'id du semestre
        /// </summary>
        public int Id { get => id; set => id = value; }

        /// <summary>
        /// Récupère et remplace le nom du semestre (équivalent à une promotion)
        /// </summary>
        public string Name { get => name; set => name = value; }

        /// <summary>
        /// Récupère et remplace le numéro de la semaine de début du semestre
        /// </summary>
        public int SemesterWeekBegin { get => semesterWeekBegin; set => semesterWeekBegin = value; }

        /// <summary>
        /// Récupère et remplace le numéro de la semaine de fin du semestre
        /// </summary>
        public int SemesterWeekEnd { get => semesterWeekEnd; set => semesterWeekEnd = value; }

        /// <summary>
        /// Récupère et remplace le nombre de groupe de TP par semestre
        /// </summary>
        /// <exception> Un nombre de groupe de TP ne peut pas être négatif </exception>
        public int NbTpGroups { get => nbTpGroups; 
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Le nombre de groupe de TP ne peut pas être négatif");
                }
                else
                {
                    nbTpGroups = value;
                }
            }
        }



        /// <summary>
        /// Constructeur de semestre avec tous les paramètres
        /// </summary>
        /// <param name="name">nom du semestre</param>
        /// <param name="nbTpGroups">nbre de groupe de TP</param>
        /// <param name="SemesterWeekBegin">numéro de début de semestre</param>
        /// <param name="SemesterWeekEnd">numéro de fin de semestre</param>
        public Semester(string name, int nbTpGroups, int semesterWeekBegin, int semesterWeekEnd)
        {
            this.name = name;
            this.nbTpGroups = nbTpGroups;
            this.semesterWeekBegin = semesterWeekBegin;
            this.semesterWeekEnd = semesterWeekEnd;
        }

        /// <summary>
        /// Constructeur de semestre vide
        /// </summary>
        public Semester()
        {

        }
    }
}
