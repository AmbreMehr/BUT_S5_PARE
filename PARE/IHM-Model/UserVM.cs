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

        public User Model
        {
            get => model;
        }

        public UserVM (User model)
        {
            this.model = model;
        }

        /// <summary>
        /// Met à jour l'utilisateur dans le backend
        /// </summary>
        public async Task UpdateUser()
        {
            
        }
    }
}
