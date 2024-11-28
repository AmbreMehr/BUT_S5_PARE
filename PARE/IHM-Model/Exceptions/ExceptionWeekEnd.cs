using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IHM_Model.Exceptions
{
    /// <summary>
    /// Exception levée lorsque la semaine de début est inférieure à 35 ou supérieure à 53 : positionnement module
    /// </summary>
    public class ExceptionWeekEnd : Exception
    {
        /// <summary>
        /// Initialise une nouvelle instance de la classe ExceptionHourEnd
        /// </summary>
        /// <param name="message">message par défaut</param>
        public ExceptionWeekEnd(string message) : base(message)
        {
        }

    }
}
