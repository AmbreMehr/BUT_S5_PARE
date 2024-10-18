using System;
using System.Collections.Generic;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;

namespace IHM.Ressources
{
    public class RessourcesManager
    {
        #region Singleton

        private static RessourcesManager instance;

        /// <summary>
        /// Renvoie la seule instance de RessourceManager
        /// </summary>
        /// <author>Nordine</author>
        public static RessourcesManager Instance
        {
            get
            {
                if (instance == null) instance = new RessourcesManager();
                return instance;
            }
        }
        #endregion

    }
}
