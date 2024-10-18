using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace Network
{
    public class ModuleNetwork : IModuleNetwork
    {
        public async Task<Module[]> GetAllModules()
        {
            IEnumerable<Module> modules = new List<Module>();
            using (var client = new HttpClient())
            {
                string query = NetworkConfiguration.Instance.ApiUrl + "api/module/GetAllModules";
                HttpResponseMessage response = await client.GetAsync(query);
                if (response.IsSuccessStatusCode)
                {
                    modules = await response.Content.ReadFromJsonAsync(typeof(IEnumerable<Module>)) as IEnumerable<Module>;
                }
            }
            return modules.ToArray();
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
