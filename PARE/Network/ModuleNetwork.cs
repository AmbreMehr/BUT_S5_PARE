using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Network
{
    public class ModuleNetwork : IModuleNetwork
    {
        public async Task<Module[]> GetAllModules()
        {
            throw new NotImplementedException();
        }

        public async Task<int> GetHoursByWeek(int week)
        {
            throw new NotImplementedException();
        }

        public async Task<Module[]> GetModuleBySemester(int semester)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateModule(Module module)
        {
            throw new NotImplementedException();
        }
    }
}
