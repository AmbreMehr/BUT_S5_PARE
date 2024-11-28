using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IHM_Model.Exceptions
{
    public class ExceptionHourNegative : Exception
    {
        public ExceptionHourNegative(string message = "Les heures assignés à l'enseignant sont négatives et ne peuvent pas être validées.") : base(message)
        {
        }

    }
}
