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
        /// Propriété pour obtenir le tableau des utilisateursVM.
        /// </summary>
        public List<UserVM> Users
        { 
            get { return models; }
        }

        /// <summary>
        /// Permet de récupérer et modifier l'utilisateur sélectionné.
        /// </summary>
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
        /// Récupère tous les enseignants
        /// </summary>
        /// <param name="role">role de l'utilisateur</param>
        /// <returns>UserVM list</returns>
        public async Task<List<UserVM>> GetAllProfessors()
        {
            models.Clear();
            User[] users = await network.GetUsersByRole(Roles.Professor);
            foreach (User professor in users)
            {
                models.Add(new UserVM(professor));
            }
            return models;
        }

        /// <summary>
        /// Initialise la classe UsersVM avec un tableau vide de UserVM et un UserNetwork.
        /// </summary>
        public UsersVM()
        {
            this.models = new List<UserVM>();
            this.network = new UserNetwork();
        }
    }
}
