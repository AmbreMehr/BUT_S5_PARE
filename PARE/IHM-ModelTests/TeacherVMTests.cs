using IHM_Model;
using IHM_Model.Exceptions;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IHM_ModelTests
{
    /// <summary>
    /// Tests unitaires pour la classe `TeacherVM`
    /// </summary>
    public class TeacherVMTests
    {
        /// <summary>
        /// Test de la méthode `UpdateTeacher` de la classe `TeacherVM`
        /// </summary>
        [Fact]
        public async Task TestUpdateTeacherVM()
        {
            // Création d'un enseignant, user et module
            Teacher teacher = CreateTeacher();


            TeacherVM vm = new TeacherVM(teacher);
            // Modification des heures assignées
            vm.Model.AssignedCmHours = 9;
            vm.Model.AssignedTdHours = 1;
            vm.Model.AssignedTpHours = 2;

            // Modification des heures en bdd
            vm.UpdateTeacher();


            // Vérification des heures assignées quand les données sont simple
            Assert.Equal(9, teacher.AssignedCmHours);
            Assert.Equal(1, teacher.AssignedTdHours);
            Assert.Equal(2, teacher.AssignedTpHours);

            // Modification des heures assignées - cas heure assigné > heure programme
            vm.Model.AssignedCmHours = 30;
            vm.Model.AssignedTdHours = 30;
            vm.Model.AssignedTpHours = 30;

            vm.UpdateTeacher();

            // Vérification des exceptions levées
            await Assert.ThrowsAsync<Exception>(() => vm.UpdateTeacher());

            // Modification des heures assignées - cas heure négatives
            vm.Model.AssignedCmHours = -2;
            vm.Model.AssignedTdHours = -1;
            vm.Model.AssignedTpHours = -4;

            vm.UpdateTeacher();

            // Vérification des exceptions levées
            await Assert.ThrowsAsync<Exception>(() => vm.UpdateTeacher());
        }


        /// <summary>
        /// Test de la méthode `CreateTeacher` de la classe `TeacherVM`
        /// </summary>
        [Fact]
        public async Task TestCreateTeacherVMAsync()
        {
            TeachersVM teachersVMQuery = new TeachersVM();
            // Création d'un enseignant et du vm
            Teacher teacher = CreateTeacher();
            TeacherVM vm = new TeacherVM(teacher);
            vm.Model.Id = 0;

            vm.CreateTeacher();

            // Vérification des heures assignées quand les données sont simple
            Assert.Equal(5, teacher.AssignedCmHours);
            Assert.Equal(8, teacher.AssignedTdHours);
            Assert.Equal(10, teacher.AssignedTpHours);


            // Modification des heures assignées - cas heure assigné > heure programme
            TeacherVM vm2 = new TeacherVM(teacher);

            vm2.Model.AssignedCmHours = 30;
            vm2.Model.AssignedTdHours = 30;
            vm2.Model.AssignedTpHours = 30;

            vm2.CreateTeacher();

            // Vérification des exceptions levées
            await Assert.ThrowsAsync<ExceptionHourProgram>(() => vm2.CreateTeacher());

            // Modification des heures assignées - cas heure négatives
            TeacherVM vm3 = new TeacherVM(teacher);

            vm3.Model.AssignedCmHours = -2;
            vm3.Model.AssignedTdHours = -1;
            vm3.Model.AssignedTpHours = -4;

            vm3.CreateTeacher();

            // Vérification des exceptions levées
            await Assert.ThrowsAsync<ExceptionHourNegative>(() => vm3.CreateTeacher());
        }

        /// <summary>
        /// Test de la méthode `DeleteTeacher` de la classe `TeacherVM`
        /// </summary>
        [Fact]
        public async Task TestDeleteTeacherVMAsync()
        {
            TeachersVM teachersVMQuery = new TeachersVM();
            // Création d'un enseignant et du vm
            Teacher teacher = CreateTeacher();
            TeacherVM vm = new TeacherVM(teacher);

            // Suppression de tous les teacherVM
            vm.DeleteTeacher();

            // Vérification de la suppression
            Assert.False(teachersVMQuery.Teachers.Contains(vm));
        }

        /// <summary>
        /// Création d'un enseignant, module et user
        /// </summary>
        /// <returns>Teacher</returns>
        private Teacher CreateTeacher()
        {
            Teacher teacher = new Teacher();
            teacher.AssignedTpHours = 10;
            teacher.AssignedCmHours = 5;
            teacher.AssignedTdHours = 8;
            teacher.Id = 1;
            teacher.User = new User();
            teacher.User.FirstName = "Bidule";
            teacher.User.LastName = "Truc";
            teacher.User.RealHours = 10;
            teacher.User.Id = 1;
            teacher.User.Roles = new List<Role>();
            teacher.User.Roles.Add(new Role());
            teacher.User.Roles[0].Id = 1;
            teacher.User.Roles[0].Name = "Enseignant";
            teacher.User.Profil = new TypicalProfile();
            teacher.User.Profil.Id = 1;
            teacher.User.Profil.Name = "Maitre de conference";
            teacher.User.Profil.ServiceHours = 192;
            Module module = new Module();
            module.Name = "Module 1";
            module.HoursTp = 10;
            module.HoursCM = 12;
            module.HoursTd = 15;
            module.Id = 1;
            module.Semester = new Semester();
            module.Semester.Id = 1;
            module.Semester.Name = "Semestre 1";
            teacher.Module = module;
            return teacher;
        }

    }
}
