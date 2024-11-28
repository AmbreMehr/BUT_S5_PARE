using Model;
using Network;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkTests
{
    public class ModuleNetworkTest
    {
        [Fact]
        public async void GetAll()
        {
            IModuleNetwork network = new ModuleNetwork();

            IEnumerable<Module> modules = await network.GetAllModules();

            Assert.NotEmpty(modules);
        }
        [Fact]
        public async void GetModulesBySemester()
        {
            IModuleNetwork network = new ModuleNetwork();

            IEnumerable<Module> modules = await network.GetModuleBySemester(1);

            Assert.NotEmpty(modules);
        }

        [Fact]
        public async void GetAllModules_NoDuplicates()
        {
            IModuleNetwork network = new ModuleNetwork();

            IEnumerable<Module> modules = await network.GetAllModules();

            // Vérifie qu'il n'y a pas de doublons par Id
            Assert.Equal(modules.Count(), modules.Select(m => m.Id).Distinct().Count());
        }

        [Fact]
        public async void GetAllModules_ValidateData()
        {
            IModuleNetwork network = new ModuleNetwork();

            IEnumerable<Module> modules = await network.GetAllModules();

            foreach (var module in modules)
            {
                Assert.True(module.WeekBegin >= 35 && module.WeekEnd <= 53,
                    "Les semaines doivent être entre 35 et 53");
                Assert.False(string.IsNullOrEmpty(module.Name), "Le nom du module ne doit pas être vide");
            }
        }

        [Fact]
        public async void GetAllModules_ResponseTime()
        {
            IModuleNetwork network = new ModuleNetwork();

            var startTime = DateTime.UtcNow;
            IEnumerable<Module> modules = await network.GetAllModules();
            var endTime = DateTime.UtcNow;

            Assert.True((endTime - startTime).TotalSeconds < 5, "L'appel API doit répondre en moins de 5 secondes");
        }

        [Theory]
        [InlineData(-1)] // Semestre invalide négatif
        [InlineData(0)]  // Semestre zéro (impossible)
        [InlineData(100)] // Semestre hors des limites connues
        public async void GetModulesBySemester_InvalidSemester(int semester)
        {
            IModuleNetwork network = new ModuleNetwork();

            // Vérifie si une exception ou une liste vide est renvoyée
            IEnumerable<Module> modules = await network.GetModuleBySemester(semester);

            Assert.Empty(modules); // On peut aussi adapter selon les attentes
        }

    }
}
