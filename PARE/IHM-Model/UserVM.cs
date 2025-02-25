﻿using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IHM_Model
{
    /// <summary>
    /// La classe `UserVM` gère les utilisateur dans l'application PARE.
    /// </summary>
    /// <author>Stéphane BASSET</author>
    public class UserVM : BaseVM
    {
        private User model;
        
        /// <summary>
        /// Retourne le service du User
        /// </summary>
        public int? ServiceHour
        {
            get => model.Profil.ServiceHours;
        }

        /// <summary>
        /// Récupère les heures réelles
        /// </summary>
        public int RealHours
        {
            get => model.RealHours;
        }

        /// <summary>
        /// Récupère le nom du profil type en chaîne de caractère
        /// </summary>
        public String? Profile
        {
            get => model.Profil.Name; 
        }



        /// <summary>
        /// Recupère l'utilisateur
        /// </summary>
        public User Model
        {
            get => model;
        }

        /// <summary>
        /// Renvoie le nom complet de l'utilisateur
        /// </summary>
        public string Fullname
        {
            get => model.FirstName + " " + model.LastName;
        }

        /// <summary>
        /// Initialise l'utilisateur
        /// </summary>
        /// <param name="model">utilisateur</param>
        public UserVM (User model)
        {
            this.model = model;
        }

        /// <summary>
        /// Compare cet objet à un autre UserVM
        /// </summary>
        /// <param name="obj">Objet à comparer</param>
        /// <returns>booléen</returns>
        public override bool Equals(object? obj)
        {
            return obj is UserVM vM &&
                   EqualityComparer<User>.Default.Equals(model, vM.model);
        }

        /// <summary>
        /// Obtiens le Hash de l'objet UserVM
        /// </summary>
        /// <returns>numéro unique de l'objet</returns>
        public override int GetHashCode()
        {
            return HashCode.Combine(model);
        }
    }
}
