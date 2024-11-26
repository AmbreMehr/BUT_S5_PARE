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
        /// <summary>
        /// Récuppère tout les Modules depuis l'API
        /// </summary>
        /// <param name="module"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        /// <author>AmbreMehr</author>
        public async Task<Module[]> GetAllModules()
        {
            IEnumerable<Module> modules = new List<Module>();
            using (HttpClient? client = NetworkConfiguration.Instance.HttpClient)
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

        /// <summary>
        /// Obtient les différents modules en fonction des semestres depuis l'API
        /// </summary>
        /// <param name="module"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        /// <author>AmbreMehr</author>
        public async Task<Module[]> GetModuleBySemester(int semester)
        {
            IEnumerable<Module> modules = new List<Module>();
            using (HttpClient? client = NetworkConfiguration.Instance.HttpClient)
            {
                string query = NetworkConfiguration.Instance.ApiUrl + "api/module/GetModulesBySemester?semester=" + semester;
                HttpResponseMessage response = await client.GetAsync(query);
                if (response.IsSuccessStatusCode)
                {
                    modules = await response.Content.ReadFromJsonAsync(typeof(IEnumerable<Module>)) as IEnumerable<Module>;
                }
            }
            return modules.ToArray();
        }

        /// <summary>
        /// Met à jour les modules qui ont été modifiés dans l'API
        /// </summary>
        /// <param name="module"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task UpdateModule(Module module)
        {
            using (HttpClient? client = NetworkConfiguration.Instance.HttpClient)
            {
                string query = NetworkConfiguration.Instance.ApiUrl + "api/module/UpdateModule";
                HttpResponseMessage response = await client.PutAsJsonAsync(query, module);
                if (!response.IsSuccessStatusCode)
                {
                    // En cas d'erreur, lever une exception ou gérer l'erreur
                    string error = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Erreur lors de la mise à jour du module : {response.StatusCode}, Détails : {error}");
                }
            }
        }
    }
}
