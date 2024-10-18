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
            using (var client = new HttpClient())
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
    }
}
