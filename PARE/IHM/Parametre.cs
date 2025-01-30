using IHM.PaternObserver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace IHM
{
    /// <summary>
    /// Singleton qui stocke les paramètres
    /// </summary>
    public class Parametre : Observable
    {
        #region Singleton

        private static Parametre instance;

        /// <summary>
        /// Renvoi la seule instance de Parametre
        /// </summary>
        /// <author>Lucas</author>
        public static Parametre Instance
        {
            get
            {
                if (instance == null) instance = new Parametre();
                return instance;
            }
        }

        private Parametre() : base() { }

        #endregion

        private LANGUE langue;

        [DataMember]
        /// <summary>
        /// Langue des paramètres
        /// </summary>
        /// <author>Lucas</author>
        public LANGUE Langue
        {
            get { return this.langue; }

            set
            {
                this.langue = value;
                this.Notifier(value.ToString());
            }
        }
    }
}
