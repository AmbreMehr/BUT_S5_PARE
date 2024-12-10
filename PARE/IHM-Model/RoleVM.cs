using Model;

namespace IHM_Model
{
    /// <summary>
    /// VueModèle pour la classe Role
    /// </summary>
    public class RoleVM : BaseVM
    {
        private Role model;

        /// <summary>
        /// Renvoie le nom du role
        /// </summary>
        public String Name
        {
            get => model.Name;
        }

        /// <summary>
        /// Constructeur de la classe RoleVM avec son modèle.
        /// </summary>
        /// <param name="model">Objet Role</param>
        public RoleVM(Role model) 
        {
            this.model = model;
        }
    }
}