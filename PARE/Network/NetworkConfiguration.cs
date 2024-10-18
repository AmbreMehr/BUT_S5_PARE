using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace Network
{
    internal class NetworkConfiguration
    {
        private NetworkParameters parameters;
        private static NetworkConfiguration instance;

        private NetworkConfiguration() 
        {
            string currentDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string fileName = System.IO.Path.Combine(currentDirectory, "networkConfig.json");
            DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(NetworkParameters));
            if (File.Exists(fileName))
            {
                FileStream flux = new FileStream(fileName, FileMode.Open, FileAccess.Read);
                this.parameters = ser.ReadObject(flux) as NetworkParameters;
                flux.Close();
            } 
            else
            {
                FileStream flux = new FileStream(fileName, FileMode.Create);
                ser.WriteObject(flux, new NetworkParameters());
                flux.Close();
                throw new NoConfigurationException(fileName);
            }
        }

        public static NetworkConfiguration Instance
        {
            get
            {
                if (instance == null) instance = new NetworkConfiguration();
                return instance;
            }
        }

        public string ApiUrl { get => this.parameters.ApiUrl; }
    }
}
