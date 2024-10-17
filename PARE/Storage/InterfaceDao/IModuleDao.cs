using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace Storage.InterfaceDAO
{
    /// <summary>
    /// Interface qui permet de gérer les données des modules 
    /// </summary>
    /// <author>Clotilde MALO</author>
    public interface IModuleDao
    {
        /// <summary>
        /// Met à jour le module
        /// </summary>
        /// <param name="module">module mis à jour</param>
        public void Update(Module module);

        /// <summary>
        /// Renvoi tous les modules
        /// </summary>
        /// <returns>modules</returns>
        public Module[] ListAll();
    }
}
