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
    }
}
