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

        [Fact]
        public async void GetAllSemesters_NoDuplicates()
        {
            ISemesterNetwork network = new SemesterNetwork();

            IEnumerable<Semester> semesters = await network.GetAllSemesters();

            // Vérifie qu'il n'y a pas de doublons par ID
            Assert.Equal(semesters.Count(), semesters.Select(s => s.Id).Distinct().Count());
        }

        [Fact]
        public async void GetAllSemesters_ValidateData()
        {
            ISemesterNetwork network = new SemesterNetwork();

            IEnumerable<Semester> semesters = await network.GetAllSemesters();

            foreach (var semester in semesters)
            {
                Assert.False(string.IsNullOrEmpty(semester.Name), "Le nom du semestre ne doit pas être vide");
                Assert.True(semester.Id > 0, "L'ID du semestre doit être positif");
            }
        }

        [Fact]
        public async void GetAllSemesters_ResponseTime()
        {
            ISemesterNetwork network = new SemesterNetwork();

            var startTime = DateTime.UtcNow;
            IEnumerable<Semester> semesters = await network.GetAllSemesters();
            var endTime = DateTime.UtcNow;

            Assert.True((endTime - startTime).TotalSeconds < 5, "L'appel API doit répondre en moins de 5 secondes");
        }

        [Fact]
        public async void GetAllSemesters_InvalidData()
        {
            ISemesterNetwork network = new SemesterNetwork();

            IEnumerable<Semester> semesters = await network.GetAllSemesters();

            foreach (var semester in semesters)
            {
                Assert.NotNull(semester); // Vérifie que le semestre n'est pas null
                Assert.False(string.IsNullOrWhiteSpace(semester.Name), "Le nom ne peut pas être vide ou null");
            }
        }

        [Fact]
        public async void GetAllSemesters_CheckOrder()
        {
            ISemesterNetwork network = new SemesterNetwork();

            IEnumerable<Semester> semesters = await network.GetAllSemesters();

            Assert.True(semesters.SequenceEqual(semesters.OrderBy(s => s.Id)), "Les semestres doivent être triés par ID");
        }


    }
}