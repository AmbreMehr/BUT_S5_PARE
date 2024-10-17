using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;

namespace Storage
{
    /// <summary>
    /// Classe qui permet de gérer la base de données SQLite
    /// </summary>
    /// <author> Clotilde MALO </author>
    public class DatabaseSqlite
    {
        private SqliteConnection connection;
        private string fileName = "bdd.db";

        /// <summary>
        /// Retourne la connexion à la base de données
        /// </summary>
        public SqliteConnection Connection
        {
            get => this.connection;
        }

        /// <summary>
        /// Constructeur de la connexion base de données SQLite
        /// </summary>
        /// <param name="fileName"></param>
        public DatabaseSqlite()
        {
            string currentDirectory = AppDomain.CurrentDomain.BaseDirectory;
            this.fileName = System.IO.Path.Combine(currentDirectory, "bdd.db");
            this.connection = new SqliteConnection("Data Source=" + this.fileName);
        }
    }
}
