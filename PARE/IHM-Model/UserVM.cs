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
        private UserVM _model;

        public UserVM User
        {
            get { return _model; }
            set
            {
                _model = value;
                NotifyChange("User");
            }
        }
        /// <summary>
        /// Update un Utilisateur.
        /// </summary>
        /// <author>Stéphane BASSET</author>
        public void UpdateUser(UserVM user)
        {
            _model = user;
        }
    }
}
