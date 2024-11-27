using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace Network
{
    public class TeacherNetwork : ITeacherNetwork
    {
        public async Task CreateTeacher(Teacher teacher)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteTeacher(Teacher teacher)
        {
            throw new NotImplementedException();
        }

        public async Task<Teacher[]> GetTeachersByModule(Module module)
        {
            IEnumerable<Teacher> semesters = new List<Teacher>();
            using (var client = NetworkConfiguration.Instance.HttpClient)
            {
                string query = NetworkConfiguration.Instance.ApiUrl + "api/teacher/GetTeachersByModule?idModule=" + module.Id.ToString();
                HttpResponseMessage response = await client.GetAsync(query);
                if (response.IsSuccessStatusCode)
                {
                    semesters = await response.Content.ReadFromJsonAsync(typeof(IEnumerable<Teacher>)) as IEnumerable<Teacher>;
                }
            }
            return semesters.ToArray();
        }

        public async Task UpdateTeacher(Teacher teacher)
        {
            throw new NotImplementedException();
        }
    }
}
