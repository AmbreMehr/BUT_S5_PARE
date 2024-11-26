using Microsoft.Data.Sqlite;
using Model;
using Storage.InterfaceDAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Storage
{
    /// <summary>
    /// Gère les données des modules
    /// </summary>
    /// <author>Clotilde MALO</author>
    public class ModuleDaoSqlite : IModuleDao
    {
        private DatabaseSqlite db;

        /// <summary>
        /// Constructeur de base pour initialiser la connexion
        /// </summary>
        public ModuleDaoSqlite()
        {
            db = new DatabaseSqlite();
        }


        public Module[] ListAll()
        {
            List<Module> modules = new List<Module>();
            db.Connection.Open();
            var cmd = db.Connection.CreateCommand();
            cmd.CommandText = "SELECT" +
                               " idModule" +
                               ", name" +
                               ", hourTP" +
                               ", hourTD" +
                               ", hourCM" +
                               ", weekBegin" +
                               ", weekEnd" +
                               ", m.idSemester" +
                               ", nameSemester" +
                               ", numberGroupTp" +
                               " FROM Modules AS m" +
                               " LEFT JOIN Semester AS s ON m.idSemester = s.idSemester;";
            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    modules.Add(Reader2Module(reader));
                }
            }
            db.Connection.Close();

            return modules.ToArray();
        }

        public void Update(Module module)
        {
            List<Module> modules = new List<Module>();

            Console.WriteLine($"Updating Module: {module.Id}, {module.WeekBegin}, {module.WeekEnd}");


            db.Connection.Open();
            var cmd = db.Connection.CreateCommand();
            cmd.CommandText = "UPDATE Modules " +
                  "SET weekBegin = @weekBegin, " +
                  "weekEnd = @weekEnd " +
                  "WHERE idModule = @idModule;";

            // Ajout des paramètres avec leurs valeurs
            cmd.Parameters.AddWithValue("@weekBegin", module.WeekBegin);
            cmd.Parameters.AddWithValue("@weekEnd", module.WeekEnd);
            cmd.Parameters.AddWithValue("@idModule", module.Id);

            // Exécuter la commande
            int rowsAffected = cmd.ExecuteNonQuery();
            db.Connection.Close();

            // Vérification si aucune ligne n'a été mise à jour
            if (rowsAffected == 0)
            {
                throw new InvalidOperationException($"No module found with id {module.Id}");
            }

        }

        public Module[] GetAllBySemester(int semesterId)
        {
            List<Module> modules = new List<Module>();
            db.Connection.Open();
            var cmd = db.Connection.CreateCommand();
            cmd.CommandText = "SELECT" +
                               " idModule" +
                               ", name" +
                               ", hourTP" +
                               ", hourTD" +
                               ", hourCM" +
                               ", weekBegin" +
                               ", weekEnd" +
                               ", m.idSemester" +
                               ", nameSemester" +
                               ", numberGroupTp" +
                               " FROM Modules AS m" +
                               " LEFT JOIN Semester AS s ON m.idSemester = s.idSemester" +
                               " WHERE m.idSemester = @semesterId;";
            cmd.Parameters.AddWithValue("@semesterId", semesterId);
            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    modules.Add(Reader2Module(reader));
                }
            }
            db.Connection.Close();

            return modules.ToArray();
        }

        public Module Reader2Module(SqliteDataReader reader)
        {
            Module module = new Module();
            module.Id = Convert.ToInt32(reader["idModule"]);
            module.Name = reader["name"].ToString();
            module.HoursTp = Convert.ToInt32(reader["hourTP"]);
            module.HoursTd = Convert.ToInt32(reader["hourTD"]);
            module.HoursCM = Convert.ToInt32(reader["hourCM"]);
            module.WeekBegin = Convert.ToInt32(reader["weekBegin"]);
            module.WeekEnd = Convert.ToInt32(reader["weekEnd"]);
            ISemesterDao semesterDao = new SemesterDaoSqlite();
            module.Semester = semesterDao.Reader2Semester(reader);
            return module;

        }
    }
}
