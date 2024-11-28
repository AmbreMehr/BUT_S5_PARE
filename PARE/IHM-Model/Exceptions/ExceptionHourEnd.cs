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
    public class ExceptionHourEnd : Exception
    {
        /// <summary>
        /// Initialise une nouvelle instance de la classe ExceptionHourEnd
        /// </summary>
        /// <param name="message">message par défaut</param>
        public ExceptionHourEnd(string message = "La semaine de fin doit être comprise entre 35 et 53.") : base(message)
        {
        }

    }
}
