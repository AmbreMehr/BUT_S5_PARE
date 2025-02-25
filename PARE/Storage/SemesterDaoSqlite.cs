﻿using Microsoft.Data.Sqlite;
using Model;
using Storage.InterfaceDAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Storage
{
    /// <summary>
    /// Gère les données des semestres
    /// </summary>
    /// <author>Clotilde MALO</author>
    public class SemesterDaoSqlite : ISemesterDao
    {
        private DatabaseSqlite db;

        /// <summary>
        /// Constructeur de base pour initialiser la connexion
        /// </summary>
        public SemesterDaoSqlite()
        {
            db = new DatabaseSqlite();
        }
        public Semester[] ListAll()
        {
            List<Semester> semesters = new List<Semester>();
            db.Connection.Open();
            var cmd = db.Connection.CreateCommand();
            cmd.CommandText = "SELECT" +
                               " idSemester" +
                               ", nameSemester" +
                               ", numberGroupTp" +
                               ", SemesterWeekBegin" +
                               ", SemesterWeekEnd"+
                               " FROM Semester;";
            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    semesters.Add(Reader2Semester(reader));
                }
            }
            db.Connection.Close();

            return semesters.ToArray();
        }


        public Semester Reader2Semester(SqliteDataReader reader)
        {
            Semester semester = new Semester();
            semester.Id = Convert.ToInt32(reader["idSemester"]);
            semester.Name = reader["nameSemester"].ToString();
            semester.NbTpGroups = Convert.ToInt32(reader["numberGroupTp"]);
            semester.SemesterWeekBegin = Convert.ToInt32(reader["SemesterWeekBegin"]);
            semester.SemesterWeekEnd = Convert.ToInt32(reader["SemesterWeekEnd"]);

            return semester;
        }
    }
}
