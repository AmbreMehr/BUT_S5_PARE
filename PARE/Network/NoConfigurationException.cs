using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Network
{
    public class NoConfigurationException : Exception
    {
        public NoConfigurationException(string configFileName) : base("There is no configuration in " + configFileName + ".\nPlease complete the configuration file.") { }
    }
}
