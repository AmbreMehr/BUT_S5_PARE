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
        private List<RoleVM> models;
        
        public List<RoleVM> Roles
        {     
            get { return models; }
        }

        public RolesVM()
        {
            models = new List<RoleVM>();
        }
    }
}
