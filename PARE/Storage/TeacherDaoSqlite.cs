﻿using Microsoft.Data.Sqlite;
using Model;
using Storage.InterfaceDAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Storage
{
    /// <summary>
    /// Gère les données des enseignants d'un module
    /// </summary>
    /// <author>Clotilde MALO</author>
    public class TeacherDaoSqlite : ITeacherDao
    {
        private DatabaseSqlite db;

        /// <summary>
        /// Constructeur de base pour initialiser la connexion
        /// </summary>
        public TeacherDaoSqlite()
        {
            db = new DatabaseSqlite();
        }

        public Teacher[] ListForModule(int idModule)
        {
            List<Teacher> teachers = new List<Teacher>();
              db.Connection.Open();
              var cmd = db.Connection.CreateCommand();
            cmd.CommandText = "SELECT" +
                                " idTeacherOfModule" +
                                ", t.assignedTDHours" +
                                ", t.assignedCMHours" +
                                ", t.assignedTPHours" +
                                ", t.idUser" +
                                ", u.firstname" +
                                ", u.lastname" +
                                ", u.realHours" +
                                ", u.idTypicalProfile" +
                                ", m.idModule" +
                                ", m.name" +
                                ", m.hourTD" +
                                ", m.hourTP" +
                                ", m.hourCM" +
                                ", m.weekBegin" +
                                ", m.weekEnd" +
                                ", m.idSemester" +
                                ", m.supervisor" +
                                ", s.idSemester" +
                                ", s.nameSemester" +
                                ", s.numberGroupTp" +
                                ", tp.idTypicalProfile" +
                                ", tp.nameTypicalProfile" +
                                ", tp.serviceHours" +
                                ", r.idRole" +
                                ", r.roleName" +
                                ", ru.idRole" +
                                ", ru.idUser" +
                                ", SemesterWeekBegin" +
                                ", SemesterWeekEnd" +
                                " FROM" +
                                " TeacherOfModule AS t" +
                                " LEFT JOIN Users AS u ON u.idUser = t.idUser" +
                                " LEFT JOIN Modules AS m ON m.idModule = t.idModule" +
                                " LEFT JOIN Semester AS s ON s.idSemester = m.idSemester" +
                                " LEFT JOIN TypicalProfile AS tp ON tp.idTypicalProfile = u.idTypicalProfile" +
                                " LEFT JOIN RoleOfUser AS ru ON u.idUser = ru.idUser" +
                                " LEFT JOIN Role AS r ON r.idRole = ru.idRole" +
                                " WHERE t.idModule = @moduleId" +
                                " GROUP BY idTeacherOfModule;";
              cmd.Parameters.AddWithValue("@moduleId", idModule);
        
              using (var reader = cmd.ExecuteReader())
              {
                while (reader.Read())
                {
                    teachers.Add(Reader2Teacher(reader));
                }
              }
              db.Connection.Close();

              return teachers.ToArray();
        }

        public void Update(Teacher teacher)
        {
            if (teacher == null || teacher.User == null)
                throw new ArgumentNullException(nameof(teacher), Ressource.StringRes.TeacherOrUserNull);


            // Récupération de l'id de l'enseignant avant la modification - pour mettre à jour les heures réelles si changement d'enseignant
            db.Connection.Open();
            var cmd1 = db.Connection.CreateCommand();
            cmd1.CommandText = "SELECT idUser FROM TeacherOfModule WHERE idTeacherOfModule = @idTeacher;";
            cmd1.Parameters.AddWithValue("@idTeacher", teacher.Id);
            int idTeacherBefore = 0;
            using (var reader = cmd1.ExecuteReader())
            {
                reader.Read();
                idTeacherBefore = Convert.ToInt32(reader["idUser"]);

            }


            var cmd = db.Connection.CreateCommand();
            cmd.CommandText = "UPDATE TeacherOfModule " +
                  "SET idUser = @idUser, " +
                  "assignedCMHours = @CMHours, " +
                  "assignedTDHours = @TDHours, " +
                  "assignedTPHours = @TPHours " +
                  "WHERE idTeacherOfModule = @idTeacher;";

            cmd.Parameters.AddWithValue("@idUser", teacher.User.Id);
            cmd.Parameters.AddWithValue("@CMHours", teacher.AssignedCmHours);
            cmd.Parameters.AddWithValue("@TDHours", teacher.AssignedTdHours);
            cmd.Parameters.AddWithValue("@TPHours", teacher.AssignedTpHours);
            cmd.Parameters.AddWithValue("@idTeacher", teacher.Id);

            

            cmd.ExecuteNonQuery();


            db.Connection.Close();
            // Mise à jour des heures réelles s'il y a eu un changement d'enseignant
            if (idTeacherBefore != teacher.User.Id)
            {
                UpdateRealHours(idTeacherBefore);
            }
            UpdateRealHours(teacher.User.Id);

        }

        public Teacher Reader2Teacher(SqliteDataReader reader)
        {
            UserDaoSqlite userDao = new UserDaoSqlite();
            ModuleDaoSqlite moduleDao = new ModuleDaoSqlite();

            Teacher teacher = new Teacher();
            teacher.Module = moduleDao.Reader2Module(reader);
            teacher.User = userDao.Reader2User(reader);

            teacher.AssignedCmHours = Convert.ToInt32(reader["assignedCMHours"]);
            teacher.AssignedTdHours = Convert.ToInt32(reader["assignedTDHours"]);
            teacher.AssignedTpHours = Convert.ToInt32(reader["assignedTPHours"]);
            teacher.Id = Convert.ToInt32(reader["idTeacherOfModule"]);



            return teacher;

        }

        public void Delete(Teacher teacher)
        {
            if (teacher == null)
                throw new ArgumentNullException(nameof(teacher), "Teacher ne peut pas être null.");


            db.Connection.Open();
            var cmd = db.Connection.CreateCommand();
            cmd.CommandText = "DELETE" +
                               " FROM TeacherOfModule" +
                               " WHERE idTeacherOfModule = @idTeacher;";

            cmd.Parameters.AddWithValue("@idTeacher", teacher.Id);


            cmd.ExecuteNonQuery();
            db.Connection.Close();
            UpdateRealHours(teacher.User.Id);

        }

        public void Create(Teacher teacher)
        {
            if (teacher == null)
                throw new ArgumentNullException(nameof(teacher), "Teacher ne peut pas être null.");


            db.Connection.Open();
            var cmd = db.Connection.CreateCommand();
            cmd.CommandText = "INSERT" +
                               " INTO TeacherOfModule" +
                               " (idTeacherOfModule, assignedTDHours, assignedTPHours, assignedCMHours, idUser, idModule)" +
                               " VALUES" +
                               " (NULL, @assignedTDHours, @assignedTPHours, @assignedCMHours, @idUser, @idModule);";

            cmd.Parameters.AddWithValue("@assignedTDHours", teacher.AssignedTdHours);
            cmd.Parameters.AddWithValue("@assignedTPHours", teacher.AssignedTpHours);
            cmd.Parameters.AddWithValue("@assignedCMHours", teacher.AssignedCmHours);
            cmd.Parameters.AddWithValue("@idUser", teacher.User.Id);
            cmd.Parameters.AddWithValue("@idModule", teacher.Module.Id);


            cmd.ExecuteNonQuery();
            db.Connection.Close();

            UpdateRealHours(teacher.User.Id);
        }


        public Teacher[] ListForUser(int idUser)
        {
            List<Teacher> teachers = new List<Teacher>();
            db.Connection.Open();
            var cmd = db.Connection.CreateCommand();
            cmd.CommandText = "SELECT" +
                                " idTeacherOfModule" +
                                ", t.assignedTDHours" +
                                ", t.assignedCMHours" +
                                ", t.assignedTPHours" +
                                ", t.idUser" +
                                ", u.firstname" +
                                ", u.lastname" +
                                ", u.realHours" +
                                ", u.idTypicalProfile" +
                                ", m.idModule" +
                                ", m.name" +
                                ", m.hourTD" +
                                ", m.hourTP" +
                                ", m.hourCM" +
                                ", m.weekBegin" +
                                ", m.weekEnd" +
                                ", m.idSemester" +
                                ", m.supervisor" +
                                ", s.idSemester" +
                                ", s.nameSemester" +
                                ", s.numberGroupTp" +
                                ", tp.idTypicalProfile" +
                                ", tp.nameTypicalProfile" +
                                ", tp.serviceHours" +
                                ", r.idRole" +
                                ", r.roleName" +
                                ", ru.idRole" +
                                ", ru.idUser" +
                                ", SemesterWeekBegin" +
                                ", SemesterWeekEnd" +
                                " FROM" +
                                " TeacherOfModule AS t" +
                                " LEFT JOIN Users AS u ON u.idUser = t.idUser" +
                                " LEFT JOIN Modules AS m ON m.idModule = t.idModule" +
                                " LEFT JOIN Semester AS s ON s.idSemester = m.idSemester" +
                                " LEFT JOIN TypicalProfile AS tp ON tp.idTypicalProfile = u.idTypicalProfile" +
                                " LEFT JOIN RoleOfUser AS ru ON u.idUser = ru.idUser" +
                                " LEFT JOIN Role AS r ON r.idRole = ru.idRole" +
                                " WHERE u.idUser = @idUser" +
                                " GROUP BY idTeacherOfModule;";
            cmd.Parameters.AddWithValue("@idUser", idUser);

            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    teachers.Add(Reader2Teacher(reader));
                }
            }
            db.Connection.Close();

            return teachers.ToArray();
        }

        /// <summary>
        /// Calcul et met à jour les heures réelles de l'utilisateur - appel de la méthode de UserDaoSqlite
        /// </summary>
        /// <param name="userId">id de l'utilisateur</param>
        private void UpdateRealHours(int userId)
        {
            // Récupération des heures réelles 
            int realHours = 0;
            Teacher[] teachers = ListForUser(userId);
            foreach(Teacher t in teachers)
            {
                realHours += t.AssignedCmHours 
                    + (t.AssignedTdHours * (t.Module.Semester.NbTpGroups / 2 + t.Module.Semester.NbTpGroups % 2) 
                    + (t.AssignedTpHours * t.Module.Semester.NbTpGroups));
            }
            // Mise à jour des heures réelles
            UserDaoSqlite userDao = new UserDaoSqlite();
            userDao.UpdateRealHours(userId, realHours); 
        }
    }
}
