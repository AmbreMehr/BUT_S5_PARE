using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IHM_Model.Exceptions
{
    /// <summary>
    /// Exception levée lorsque les heures de début sont supérieures aux heures de fin : positionnement module
    /// </summary>
    public class ExceptionHourBeginAfterHourEnd : Exception
    {
        /// <summary>
        /// Initialise une nouvelle instance de la classe ExceptionHourProgram
        /// </summary>
        /// <param name="message">message par défaut</param>
        public ExceptionHourBeginAfterHourEnd(string message = "La semaine de début ne peut pas être supérieure à la semaine de fin") : base(message)
        {
        }

    }
}
