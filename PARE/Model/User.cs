using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    /// <summary>
    /// Classe qui représente l'utilisateur
    /// </summary>
    /// <author>Clotilde MALO</author>
    public class User
    {
        private List<Role> roles;
        private TypicalProfile profil;
        private int id;
        private string firstName;
        private string lastName;
        private int realHours;

        /// <summary>
        /// get et set de l'id utilisateur
        /// </summary>
        public int Id { get => id; set => id = value; }

        /// <summary>
        /// get et set du prénom utilisateur
        /// </summary>
        public string FirstName { get => firstName; set => firstName = value; }

        /// <summary>
        /// get et set du nom utilisateur
        /// </summary>
        public string LastName { get => lastName; set => lastName = value; }

        /// <summary>
        /// get et set des heures réelles travaillées par l'utilisateur
        /// <exception> Si les heures sont négatives relève une exception </exception>
        /// </summary>
        public int RealHours { 
            get => realHours;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Les heures réelles ne peuvent pas être négatives");
                }
                else
                {
                    realHours = value;
                }
            }
            }
        /// <summary>
        /// Get et set d profil type de l'utilisateur
        /// </summary>
        public TypicalProfile Profil { get => profil; set => profil = value; }

        /// <summary>
        /// Get et set des rôle de l'utilisateur
        /// </summary>
        public List<Role> Roles 
        { 
            get => roles;
            set
            {
                this.roles.Clear();
                foreach (Role role in value)
                {
                    this.roles.Add(role);
                }
            }
        }

        /// <summary>
        /// Constructeur d'utilisateur avec id, prénom, nom, heure
        /// </summary>
        /// <param name="id">id utilisateur</param>
        /// <param name="firstName">prénom utilisateur</param>
        /// <param name="lastName">nom utilisateur</param>
        /// <param name="realHours">heures travaillés par l'utilisateur</param>
        public User(int id, string firstName, string lastName, int realHours)
        {
            this.id = id;
            this.firstName = firstName;
            this.lastName = lastName;
            this.realHours = realHours;
            this.roles = new List<Role>();
        }

        /// <summary>
        /// Constructeur d'utilisateur id, prénom, nom
        /// </summary>
        /// <param name="id">id utilisateur</param>
        /// <param name="firstName">prénom utilisateur</param>
        /// <param name="lastName">nom utilisateur</param>
        public User(int id, string firstName, string lastName)
        {
            this.id = id;
            this.firstName = firstName;
            this.lastName = lastName;
            this.realHours = 0;
            this.roles = new List<Role>();
        }

        /// <summary>
        /// Constructeur d'utilisateur à vide, initialise heure réelle à 0
        /// </summary>
        public User()
        {
            this.realHours = 0;
            this.roles = new List<Role>();
        }


        /// <summary>
        /// Ajoute un rôle à l'utilisateur
        /// </summary>
        /// <param name="role">role à ajouter</param>
        public void AddRole(Role role)
        {
            this.roles.Add(role);
        }

        /// <summary>
        /// Ajoute un profil type à l'utilisateur
        /// </summary>
        /// <param name="profile">profil type</param>
        public void AddTypicalProfile(TypicalProfile profile)
        {
            this.profil = profile;
        }


        /// <summary>
        /// Renvoi l'utilisateur sous forme de chaine de caractères
        /// </summary>
        /// <returns>prénom, nom</returns>
        public string ToString()
        {
            return this.firstName + " " + this.lastName;
        }

        public override bool Equals(object? obj)
        {
            return obj is User user &&
                   id == user.id &&
                   firstName == user.firstName &&
                   lastName == user.lastName;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(id, firstName, lastName);
        }
    }
}
