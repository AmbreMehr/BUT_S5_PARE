using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Network
{
    /// <summary>
    /// Implémentation du réseau pour gérer les utilisateurs
    /// </summary>
    public class UserNetwork : IUserNetwork
    {
        public async Task<User[]> GetUsersByRole(Roles role)
        {
            IEnumerable<User>? users = new List<User>();
            using (var client = NetworkConfiguration.Instance.HttpClient)
            {
                string query = NetworkConfiguration.Instance.ApiUrl + "api/user/GetAllByRole?roleId="+((int)role);
                HttpResponseMessage response = await client.GetAsync(query);
                if (response.IsSuccessStatusCode)
                {
                    users = await response.Content.ReadFromJsonAsync(typeof(IEnumerable<User>)) as IEnumerable<User>;
                    if (users == null) 
                        users = new List<User>();
                }
            }
            return users.ToArray();
        }
    }
}
