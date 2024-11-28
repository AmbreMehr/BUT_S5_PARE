using IHM_Model;
using Model;

namespace IHM_ModelTests
{
    public class SemesterVMTests
    {
        [Fact]
        public void TestConstructor()
        {
            Semester semester = new Semester { Name = "Semester 1" };

            SemesterVM vm = new SemesterVM(semester);

            Assert.Equal(semester, vm.Model);
        }

        [Fact]
        public void TestName()
        {
            Semester semester = new Semester { Name = "Semester 1" };
            SemesterVM vm = new SemesterVM(semester);

            string name = vm.Name;

            Assert.Equal("Semester 1", name);
        }

        [Fact]
        public void TestLinkModelViewModel()
        {
            Semester semester = new Semester { Name = "Semester 1" };
            SemesterVM vm = new SemesterVM(semester);

            semester.Name = "Updated Semester";

            Assert.Equal("Updated Semester", vm.Name);
        }
    }
}
