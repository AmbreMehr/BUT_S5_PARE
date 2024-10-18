using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IHM_Model
{
    /// <summary>
    /// La classe UsersVM gère les utilisateurs
    /// Le setter déclenche une notification de changement.
    /// </summary>
    /// /// <author>Stéphane BASSET</author>
    public class UsersVM : BaseVM
    {
        private User[]_models;

        /// <summary>
        /// Propriété pour obtenir ou définir le tableau des utilisateurs.
        /// </summary>
        public User[] Users
            { 
            get { return _models; } 
            set { 
                _models = value;
                NotifyChange("Users");
            }
        
        }

        /// <summary>
        /// Récupère tous les utilisateurs.
        /// </summary>
        /// <returns>Tableau des modules pour le semestre</returns>
        /// <author>Stéphane BASSET</author>
        public User[] GetAllUsers()
        {
            return _models;
        }

        /// <summary>
        /// Récupère tous lesutilisateur par role.
        /// </summary>
        /// <param name="role"></param>
        /// <returns></returns>
        /// <author>Stéphane BASSET</author>
        public User[] GetAllUsersByRole(Role role)
        {
            User[] users = GetAllUsers();
            return users;
        }
    }
}
