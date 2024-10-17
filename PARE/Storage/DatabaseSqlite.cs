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
        private string fileName="bdd.db";

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
            this.connection = new SqliteConnection(@"Data Source=" + fileName);
            this.connection.Open();
        }


    }
}
