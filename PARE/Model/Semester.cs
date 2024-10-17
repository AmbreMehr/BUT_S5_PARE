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
        private string name;
        private int nbTpGroups;

        /// <summary>
        /// Get et set du nom du semestre (équivalent à une promotion)
        /// </summary>
        public string Name { get => name; set => name = value; }

        /// <summary>
        /// Get et set du nbre de groupe de TP par semestre
        /// <exception> Un nombre de groupe de TP ne peut pas être négatif </exception>
        /// </summary>
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
        public Semester(string name, int nbTpGroups)
        {
            this.name = name;
            this.nbTpGroups = nbTpGroups;
        }

        /// <summary>
        /// Constructeur de semestre vide
        /// </summary>
        public Semester()
        {

        }
    }
}
