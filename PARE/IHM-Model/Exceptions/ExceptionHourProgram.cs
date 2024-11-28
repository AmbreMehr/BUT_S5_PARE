using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IHM_Model.Exceptions
{
    public class ExceptionHourProgram : Exception
    {
        public ExceptionHourProgram(string message = "Les heures assignés à l'enseignant doivent être inférieures ou égales aux heures du programme.") : base(message)
        {
        }

    }
}
