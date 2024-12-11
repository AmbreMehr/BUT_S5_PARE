using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace Network
{
    public class SemesterNetwork : ISemesterNetwork
    {
        /// <author>AmbreMehr</author>
        public async Task<Semester[]> GetAllSemesters()
        {
            IEnumerable<Semester> semesters = new List<Semester>();
            using (var client = NetworkConfiguration.Instance.HttpClient)
            {
                string query = NetworkConfiguration.Instance.ApiUrl + "api/semester/GetAll";
                HttpResponseMessage response = await client.GetAsync(query);
                if (response.IsSuccessStatusCode)
                {
                    semesters = await response.Content.ReadFromJsonAsync(typeof(IEnumerable<Semester>)) as IEnumerable<Semester>;
                }
            }
            return semesters.ToArray();
        }

        public async Task<Dictionary<int, float>> GetStudentsHoursPerWeek(Semester semester)
        {
            Dictionary<int, float> hoursByWeek = new Dictionary<int, float>();
            using (var client = NetworkConfiguration.Instance.HttpClient)
            {
                string query = NetworkConfiguration.Instance.ApiUrl + "api/semester/GetStudentsHoursPerWeek?semester=" + semester.Id;
                HttpResponseMessage response = await client.GetAsync(query);
                if (response.IsSuccessStatusCode)
                {
                    hoursByWeek = await response.Content.ReadFromJsonAsync(typeof(Dictionary<int, float>)) as Dictionary<int, float>;
                    if (hoursByWeek == null)
                        hoursByWeek = new Dictionary<int, float>();
                }
            }
            return hoursByWeek;
        }
    }
}
