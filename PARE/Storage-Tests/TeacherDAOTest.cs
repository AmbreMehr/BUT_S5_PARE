using Model;
using Storage;

namespace Storage_Tests
{
    /// <summary>
    /// Tests pour la classe TeacherDAO : verification des heures reelles
    /// <author>Clotilde MALO</author>
    /// </summary>
    public class TeacherDAOTest
    {
        /// <summary>
        /// Test pour verifier qu'a l'update les heures reelles de l'utilisateur sont bien mises a jour
        /// </summary>
        [Fact]
        public void TestUpdateVerifRealHours()
        {
            TeacherDaoSqlite teacherDaoSqlite = new TeacherDaoSqlite();
            Teacher teacher = teacherDaoSqlite.ListForModule(1).First();

            teacher.AssignedTpHours = 1;
            teacher.AssignedCmHours = 1;
            teacher.AssignedTdHours = 1;
            teacherDaoSqlite.Update(teacher);


            Teacher[] teachers = teacherDaoSqlite.ListForUser(teacher.User.Id);
            int assignedTpHoursTotal = 0;
            int assignedTdHoursTotal = 0;
            int assignedCmHoursTotal = 0;
            foreach (Teacher t in teachers)
            {
                assignedCmHoursTotal += t.AssignedCmHours;
                assignedTdHoursTotal += t.AssignedTdHours * (t.Module.Semester.NbTpGroups / 2 + t.Module.Semester.NbTpGroups % 2);
                assignedTpHoursTotal += t.AssignedTpHours * t.Module.Semester.NbTpGroups;
            }

            Assert.Equal((assignedCmHoursTotal + assignedTdHoursTotal + assignedTpHoursTotal), teachers[0].User.RealHours);

        }


        /// <summary>
        /// Tests pour verifier qu'a la creation les heures reelles de l'utilisateur sont bien mises a jour
        /// </summary>
        [Fact]
        public void TestCreateVerifRealHours()
        {
            Teacher teacher = CreateTeacher();


            TeacherDaoSqlite teacherDaoSqlite = new TeacherDaoSqlite();
            teacherDaoSqlite.Create(teacher);

            Teacher[] teachers = teacherDaoSqlite.ListForUser(teacher.User.Id);

            int assignedTpHoursTotal = 0;
            int assignedTdHoursTotal = 0;
            int assignedCmHoursTotal = 0;
            foreach (Teacher t in teachers)
            {
                assignedCmHoursTotal += t.AssignedCmHours;
                assignedTdHoursTotal += t.AssignedTdHours * (t.Module.Semester.NbTpGroups / 2 + t.Module.Semester.NbTpGroups % 2);
                assignedTpHoursTotal += t.AssignedTpHours * t.Module.Semester.NbTpGroups;
            }

            Assert.Equal((assignedCmHoursTotal + assignedTdHoursTotal + assignedTpHoursTotal), teachers[0].User.RealHours);

            teacherDaoSqlite.Delete(teacher);
        }

        /// <summary>
        /// Test de verification des heures reelles apres suppression
        /// </summary>
        [Fact]
        public void TestDeleteVerifRealHours()
        {
            // Creation du teacher avant de tester la suppression
            Teacher teacher = CreateTeacher(); // creation du teacher cote "client"
            TeacherDaoSqlite teacherDaoSqlite = new TeacherDaoSqlite();
            teacherDaoSqlite.Create(teacher); // creation du teacher cote bdd

            // Recuperation de l'id de l'utilisateur
            int userId = teacher.User.Id;

            Teacher teacherInBDD = teacherDaoSqlite.ListForUser(userId).Last(); // recuperation du teacher que l'on vient de cr�� pour avoir le bon id


            // Recuperation de toutes les lignes enseignants pour cet utilisateur
            Teacher[] teachers = teacherDaoSqlite.ListForUser(userId);

            // Verification des heures assign�es avant la suppression
            int assignedTpHoursTotalBeforeDelete = 0;
            int assignedTdHoursTotalBeforeDelete = 0;
            int assignedCmHoursTotalBeforeDelete = 0;
            foreach (Teacher t in teachers)
            {
                assignedTpHoursTotalBeforeDelete += t.AssignedCmHours;
                assignedTdHoursTotalBeforeDelete += t.AssignedTdHours * (t.Module.Semester.NbTpGroups / 2 + t.Module.Semester.NbTpGroups % 2);
                assignedCmHoursTotalBeforeDelete += t.AssignedTpHours * t.Module.Semester.NbTpGroups;
            }

            // Suppression du teacher
            teacherDaoSqlite.Delete(teacherInBDD);

            // Recuperation de toutes les lignes enseignants pour cet utilisateur apres suppression
            Teacher[] teachersAfter = teacherDaoSqlite.ListForUser(userId);

            // Verification des heures assignes avant la suppression
            int assignedTpHoursTotalAfterDelete = 0;
            int assignedTdHoursTotalAfterDelete = 0;
            int assignedCmHoursTotalAfterDelete = 0;
            foreach (Teacher t in teachersAfter)
            {
                assignedTpHoursTotalAfterDelete += t.AssignedCmHours;
                assignedTdHoursTotalAfterDelete += t.AssignedTdHours * (t.Module.Semester.NbTpGroups / 2 + t.Module.Semester.NbTpGroups % 2);
                assignedCmHoursTotalAfterDelete += t.AssignedTpHours * t.Module.Semester.NbTpGroups;
            }

            Assert.NotEqual((assignedCmHoursTotalAfterDelete + assignedTpHoursTotalAfterDelete + assignedTdHoursTotalAfterDelete),
                            (assignedTdHoursTotalBeforeDelete + assignedCmHoursTotalBeforeDelete + assignedTpHoursTotalBeforeDelete));



        }

        /// <summary>
        /// Creation d'un enseignant pour les tests
        /// </summary>
        /// <returns>enseignant de test</returns>
        private Teacher CreateTeacher()
        {
            Teacher teacher = new Teacher()
            {
                Id = 20,
                AssignedCmHours = 2,
                AssignedTdHours = 4,
                AssignedTpHours = 3,
            };

            UserDaoSqlite userDaoSqlite = new UserDaoSqlite();
            User user = userDaoSqlite.ListAll().First();
            teacher.User = user;

            ModuleDaoSqlite moduleDaoSqlite = new ModuleDaoSqlite();
            Module module = moduleDaoSqlite.ListAll().First();
            teacher.Module = module;

            return teacher;
        }


    }
}