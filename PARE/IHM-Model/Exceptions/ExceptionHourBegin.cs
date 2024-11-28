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
    public class ExceptionHourBegin : Exception
    {
        /// <summary>
        /// Initialise une nouvelle instance de la classe ExceptionHourBegin
        /// </summary>
        /// <param name="message">message par défaut</param>
        public ExceptionHourBegin(string message = "La semaine de début doit être comprise entre 35 et 53.") : base(message)
        {
        }
    }
}
