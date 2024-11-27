using Microsoft.Data.Sqlite;
using Model;
using Storage.InterfaceDAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public Teacher[] ListForModule(string idModule)
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
            throw new NotImplementedException();
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
          


            return teacher;

        }
    }
}
