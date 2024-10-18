using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace IHM_Model
{
    /// <summary>
    /// La classe `ModulesVM` gère les roles dans l'application PARE.
    /// </summary>
    /// <author>Stéphane BASSET</author>
    public class RolesVM : BaseVM
    {
        private Role[]_models;
        public Role[] Role
        {     
            get { return _models; } 
            set { 
                _models = value;
                NotifyChange("Role");
            }

        }


        /// <summary>
        /// Récupère les modules.
        /// </summary>
        /// <returns>Nom des modules</returns>
        /// <author>Stéphane BASSET</author>
        public Role[] GetAllRooles()
        {  
            return _models; 
        }
    }
}
