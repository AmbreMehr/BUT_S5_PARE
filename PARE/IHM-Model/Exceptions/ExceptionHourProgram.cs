using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IHM_Model.Exceptions
{
    /// <summary>
    /// Exception levée lorsque les heures assignées à l'enseignant sont supérieures aux heures du programme : édition module
    /// </summary>
    public class ExceptionHourProgram : Exception
    {
        /// <summary>
        /// Initialise une nouvelle instance de la classe ExceptionHourProgram
        /// </summary>
        /// <param name="message">message par défaut</param>
        public ExceptionHourProgram(string message) : base(message)
        {
        }

    }
}
