using Model;
using Network;

namespace NetworkTests
{
    public class SemesterNetworkTests
    {
        [Fact]
        public async void GetAll()
        {
            ISemesterNetwork network = new SemesterNetwork();
            IEnumerable<Semester> semesters = await network.GetAllSemesters();
            Assert.NotEmpty(semesters);
        }
    }
}