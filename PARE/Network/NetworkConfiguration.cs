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
    /// <summary>
    /// Configuration pour toutes les requêtes à l'API
    /// Comprends la politique de sécurité et l'URL
    /// </summary>
    /// <author>AmbreMehr</author>
    internal class NetworkConfiguration
    {
        private NetworkParameters parameters;
        private static NetworkConfiguration instance;

        private NetworkConfiguration() 
        {
            // Déserialisation de la configuration pour récupérer l'URL de l'API
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

        private HttpClient CreateHttpClient()
        {
            HttpClientHandler handler = new HttpClientHandler();
            handler.ServerCertificateCustomValidationCallback = (message, cert, chain, sslPolicyErrors) =>
            {
                return true;
            };
            return new HttpClient(handler);
        }

        /// <summary>
        /// Renvoie la seule et unique configuration réseau (singleton)
        /// </summary>
        public static NetworkConfiguration Instance
        {
            get
            {
                if (instance == null) instance = new NetworkConfiguration();
                return instance;
            }
        }
        
        /// <summary>
        /// Renvoie un client HTTP
        /// </summary>
        public HttpClient HttpClient 
        {  
            get 
            { 
                return CreateHttpClient(); 
            } 
        }

        /// <summary>
        /// Renvoie l'URL de l'API
        /// </summary>
        public string ApiUrl { get => this.parameters.ApiUrl; }
    }
}
