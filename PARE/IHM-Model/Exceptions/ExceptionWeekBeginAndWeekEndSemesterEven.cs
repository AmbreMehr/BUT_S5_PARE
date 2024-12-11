using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IHM_Model.Exceptions
{
    /// <summary>
    /// Exception levée lorsque la semaine de début est inférieure à 2 ou supérieure à 14 : positionnement module
    /// </summary>
    /// 
    public class ExceptionWeekBeginAndWeekEndSemesterEven : Exception
    {
        /// <summary>
        /// Initialise une nouvelle instance de la classe ExceptionHourBegin
        /// </summary>
        /// <param name="message"></param>
        public ExceptionWeekBeginAndWeekEndSemesterEven(string message) : base(message) 
        { 
        
        }
    }
}
