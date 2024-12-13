using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace Network
{
    /// <summary>
    /// Implémentation du réseau pour gérer les modules
    /// </summary>
    public class ModuleNetwork : IModuleNetwork
    {
        /// <summary>
        /// Récupère tout les Modules depuis l'API
        /// </summary>
        /// <returns>Tableau de Module</returns>
        /// <author>AmbreMehr</author>
        public async Task<Module[]> GetAllModules()
        {
            IEnumerable<Module>? modules = new List<Module>();
            using (HttpClient? client = NetworkConfiguration.Instance.HttpClient)
            {
                string query = NetworkConfiguration.Instance.ApiUrl + "api/module/GetAllModules";
                HttpResponseMessage response = await client.GetAsync(query);
                if (response.IsSuccessStatusCode)
                {
                    modules = await response.Content.ReadFromJsonAsync(typeof(IEnumerable<Module>)) as IEnumerable<Module>;
                    if (modules == null) 
                        modules = new List<Module>();
                }
            }
            return modules.ToArray();
        }

        /// <summary>
        /// Obtient les différents modules en fonction des semestres depuis l'API
        /// </summary>
        /// <param name="semester">Numéro du semestre</param>
        /// <returns>Tableau de Module</returns>
        /// <author>AmbreMehr</author>
        public async Task<Module[]> GetModuleBySemester(int semester)
        {
            IEnumerable<Module>? modules = new List<Module>();
            using (HttpClient? client = NetworkConfiguration.Instance.HttpClient)
            {
                string query = NetworkConfiguration.Instance.ApiUrl + "api/module/GetModulesBySemester?semester=" + semester;
                HttpResponseMessage response = await client.GetAsync(query);
                if (response.IsSuccessStatusCode)
                {
                    modules = await response.Content.ReadFromJsonAsync(typeof(IEnumerable<Module>)) as IEnumerable<Module>;
                    if (modules == null)
                        modules = new List<Module>();
                }
            }
            return modules.ToArray();
        }

        /// <summary>
        /// Met à jour les modules qui ont été modifiés dans l'API
        /// </summary>
        /// <param name="module">Module à mettre à jour</param>
        /// <exception cref="Exception">Erreur de mise à jour</exception>
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
                    throw new Exception($"{Ressource.StringRes.ModuleUpdateError} : ({response.StatusCode}), {error}");
                }
            }
        }
    }
}
