using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Storage.InterfaceDAO
{
    public interface ITypicalProfileDao
    {
        /// <summary>
        /// Renvoi les profils types
        /// </summary>
        /// <returns>profils types</returns>
        public TypicalProfile[] ListAll();
    }
}
