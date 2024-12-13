using IHM_Model;
using Model;
using Network;

namespace IHM_ModelTests
{
    public class SemesterVMTests
    {
        SemesterNetwork semesterNetwork;

        /// <summary>
        /// Teste le constructeur
        /// </summary>
        [Fact]
        public void TestConstructor()
        {
            Semester semester = new Semester { Name = "Semester 1" };

            SemesterVM vm = new SemesterVM(semester, semesterNetwork);

            Assert.Equal(semester, vm.Model);
        }

        /// <summary>
        /// Teste la création d'un nom
        /// </summary>
        [Fact]
        public void TestName()
        {
            Semester semester = new Semester { Name = "Semester 1" };
            SemesterVM vm = new SemesterVM(semester, semesterNetwork);

            string name = vm.Name;

            Assert.Equal("Semester 1", name);
        }

        /// <summary>
        /// Teste la relation Model ViewModel
        /// </summary>
        [Fact]
        public void TestLinkModelViewModel()
        {
            Semester semester = new Semester { Name = "Semester 1" };
            SemesterVM vm = new SemesterVM(semester, semesterNetwork);

            semester.Name = "Updated Semester";

            Assert.Equal("Updated Semester", vm.Name);
        }
    }
}
