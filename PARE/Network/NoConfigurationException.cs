using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Network
{
    /// <summary>
    /// Exception levée lorsque le fichier de configuration n'est pas trouvé ou initialisé.
    /// </summary>
    /// <author>AmbreMehr</author>
    public class NoConfigurationException : Exception
    {
        public NoConfigurationException(string configFileName) : base(String.Format(Ressource.StringRes.NetworkParameterNotFound, configFileName)) { }
    }
}
