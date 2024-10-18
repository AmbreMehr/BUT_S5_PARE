using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace IHM
{
    /// <summary>
    /// (De)Serialiseur de parametre
    /// </summary>
    /// <author>Lucas</author>
    public class JsonSerializerParametre
    {
        //Nom du fichier des paramètres
        private string file;

        public JsonSerializerParametre()
        {
            this.file = "settings.json";
        }

        /// <summary>
        /// Charge les parametre s'il existe
        /// </summary>
        /// <author>Lucas</author>
        public void Load()
        {
            //si les parametres existe on les deserialise
            if (File.Exists(this.file))
            {
                FileStream flux = new FileStream(file, FileMode.Open);
                DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(Parametre));
                Parametre tempParametre = ser.ReadObject(flux) as Parametre;

                //On applique les parametres deserialise au parametre de l'app
                Parametre.Instance.Langue = tempParametre.Langue;

                flux.Close();
            }
            //sinon on initialise les parametres et on les sauvegarde
            else
            {
                InitialiserParametre();
                Save();
            }

        }

        /// <summary>
        /// Initialise les parametres avec les valeurs par défaut
        /// </summary>
        /// <author>Lucas</author>
        private void InitialiserParametre()
        {
            Parametre.Instance.Langue = LANGUE.FRANCAIS;
        }

        /// <summary>
        /// Sérialise les paramètres
        /// </summary>
        /// <author>Lucas</author>
        public void Save()
        {
            FileStream flux = new FileStream(file, FileMode.Create);
            DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(Parametre));
            ser.WriteObject(flux, Parametre.Instance);
            flux.Close();
        }
    }
}
