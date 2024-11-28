using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IHM_Model.Exceptions
{
    /// <summary>
    /// Exception levée lorsque les heures assignées à l'enseignant sont négatives : édition module
    /// </summary>
    public class ExceptionHourNegative : Exception
    {
        /// <summary>
        /// Initialise une nouvelle instance de la classe ExceptionHourNegative
        /// </summary>
        /// <param name="message">message par défaut</param>
        public ExceptionHourNegative(string message = "Les heures assignés à l'enseignant sont négatives et ne peuvent pas être validées.") : base(message)
        {
        }

    }
}
