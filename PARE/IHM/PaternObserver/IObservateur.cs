using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IHM.PaternObserver
{
    /// <summary>
    /// Interface d'observateur
    /// </summary>
    /// <author>Lucas</author>
    public interface IObservateur
    {
        /// <summary>
        /// Notifie que quelque chose a changer
        /// </summary>
        /// <param name="Message">changement</param>
        /// <author>Lucas</author>
        void Notifier(string Message);
    }
}
