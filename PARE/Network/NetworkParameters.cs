using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Network
{
    /// <author>AmbreMehr</author>
    public class NetworkParameters
    {
        private string apiUrl;

        [DataMember]
        public string ApiUrl { get => apiUrl; set => apiUrl = value; }
    }
}
