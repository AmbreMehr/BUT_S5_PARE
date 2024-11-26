using Model;
using Network;
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
        private UserNetwork network;
        private List<UserVM> models;
        private UserVM? selectedUser;

        /// <summary>
        /// Propriété pour obtenir ou définir le tableau des utilisateurs.
        /// </summary>
        public List<UserVM> Users
        { 
            get { return models; }
        }

        public UserVM? SelectedUser
        {
            get { return selectedUser; }
            set
            {
                selectedUser = value;
                NotifyChange("SelectedUser");
            }
        }

        /// <summary>
        /// Récupère tous les utilisateurs par role.
        /// </summary>
        /// <param name="role"></param>
        /// <returns></returns>
        /// <author>Stéphane BASSET</author>
        public async Task<List<UserVM>> GetAllUsersByRole(Role role)
        {
            // @TODO Mettre en models le résultat de la requête
            return models;
        }

        public UsersVM()
        {
            this.models = new List<UserVM>();
            this.network = new UserNetwork();
        }
    }
}
