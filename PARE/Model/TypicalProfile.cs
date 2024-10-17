using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    /// <summary>
    /// Profil type des utilisateurs (utilisé pour le nombre d'heure de service)
    /// </summary>
    /// <author>Clotilde MALO</author>
    public class TypicalProfile
    {
        private int id;
        private string name;
        private int serviceHours;

        /// <summary>
        /// Get et set de l'id du profil type
        /// </summary>
        public int Id { get => id; set => id = value; }

        /// <summary>
        /// Get et set du nom du profil type
        /// </summary>
        public string Name { get => name; set => name = value; }

        /// <summary>
        /// Get et set du nombre d'heures de service du profil type = heures prévus
        /// <exception> Les heures de services ne peuvent pas être négatifs</exception>
        /// </summary>
        public int ServiceHours { get => serviceHours;
            set
            {
                if (serviceHours < 0)
                {
                    throw new ArgumentException("Les heures de service ne peuvent pas être négatives");
                }
                else
                {
                    serviceHours = value;
                }
            }
        }
        /// <summary>
        /// Constructeur de profil type avec tous les paramètres
        /// </summary>
        /// <param name="id">id du profil type</param>
        /// <param name="name">nom du profil type</param>
        /// <param name="serviceHours">heure de service</param>
        public TypicalProfile(int id, string name, int serviceHours)
        {
            this.id = id;
            this.name = name;
            this.serviceHours = serviceHours;
        }

        /// <summary>
        /// Constructeur du profil type vide
        /// </summary>
        public TypicalProfile()
        {

        }
    }
}
