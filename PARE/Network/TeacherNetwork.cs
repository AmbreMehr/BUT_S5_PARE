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
    /// Implémentation du réseau pour gérer les enseignants
    /// </summary>
    public class TeacherNetwork : ITeacherNetwork
    {
        public async Task CreateTeacher(Teacher teacher)
        {
            using (HttpClient? client = NetworkConfiguration.Instance.HttpClient)
            {
                string query = NetworkConfiguration.Instance.ApiUrl + "api/teacher/create";
                HttpResponseMessage response = await client.PostAsJsonAsync(query, teacher);
                if (!response.IsSuccessStatusCode)
                {
                    string error = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Erreur lors de la création de l'enseignant : {response.StatusCode}, Détails : {error}");
                }
            }
        }

        public async Task DeleteTeacher(Teacher teacher)
        {
            using (HttpClient? client = NetworkConfiguration.Instance.HttpClient)
            {
                string query = NetworkConfiguration.Instance.ApiUrl + "api/teacher/delete";
                HttpResponseMessage response = await client.PostAsJsonAsync(query, teacher);
                if (!response.IsSuccessStatusCode)
                {
                    string error = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Erreur lors de la suppression de l'enseignant : {response.StatusCode}, Détails : {error}");
                }
            }
        }

        public async Task<Teacher[]> GetTeachersByModule(Module module)
        {
            IEnumerable<Teacher> teachers = new List<Teacher>();
            using (var client = NetworkConfiguration.Instance.HttpClient)
            {
                string query = NetworkConfiguration.Instance.ApiUrl + "api/teacher/GetTeachersByModule?idModule=" + module.Id;
                HttpResponseMessage response = await client.GetAsync(query);
                if (response.IsSuccessStatusCode)
                {
                    teachers = await response.Content.ReadFromJsonAsync(typeof(IEnumerable<Teacher>)) as IEnumerable<Teacher>;
                }
            }
            return teachers.ToArray();
        }

        public async Task UpdateTeacher(Teacher teacher)
        {
            using (HttpClient? client = NetworkConfiguration.Instance.HttpClient)
            {
                string query = NetworkConfiguration.Instance.ApiUrl + "api/teacher/update";
                HttpResponseMessage response = await client.PostAsJsonAsync(query, teacher);
                if (!response.IsSuccessStatusCode)
                {
                    string error = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Erreur lors de la mise à jour de l'enseignant : {response.StatusCode}, Détails : {error}");
                }
            }
        }
    }
}
