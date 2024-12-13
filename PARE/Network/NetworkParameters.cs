using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Network
{
    /// <summary>
    /// Format du stockage des paramètres de l'API
    /// </summary>
    /// <author>AmbreMehr</author>
    public class NetworkParameters
    {
        [DataMember]
        public string ?ApiUrl { get; set; }
    }
}
