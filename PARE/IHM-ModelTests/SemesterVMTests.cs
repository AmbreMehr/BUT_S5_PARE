using IHM_Model;
using Model;
using Network;

namespace IHM_ModelTests
{
    public class SemesterVMTests
    {
        SemesterNetwork semesterNetwork;

        [Fact]
        public void TestConstructor()
        {
            Semester semester = new Semester { Name = "Semester 1" };

            SemesterVM vm = new SemesterVM(semester, semesterNetwork);

            Assert.Equal(semester, vm.Model);
        }

        [Fact]
        public void TestName()
        {
            Semester semester = new Semester { Name = "Semester 1" };
            SemesterVM vm = new SemesterVM(semester, semesterNetwork);

            string name = vm.Name;

            Assert.Equal("Semester 1", name);
        }

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
