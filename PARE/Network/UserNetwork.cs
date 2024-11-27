using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace Network
{
    public class UserNetwork : IUserNetwork
    {
        public async Task<Role[]> GetAllRoles()
        {
            throw new NotImplementedException();
        }

        public async Task<User[]> GetAllUsers()
        {
            throw new NotImplementedException();
        }

        public async Task<TypicalProfile[]> GetTypicalProfiles()
        {
            throw new NotImplementedException();
        }

        public async Task<User> GetUserById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<User[]> GetUsersByRole(Roles role)
        {
            IEnumerable<User> users = new List<User>();
            using (var client = NetworkConfiguration.Instance.HttpClient)
            {
                string query = NetworkConfiguration.Instance.ApiUrl + "api/user/GetAllByRole?roleId="+((int)role);
                HttpResponseMessage response = await client.GetAsync(query);
                if (response.IsSuccessStatusCode)
                {
                    users = await response.Content.ReadFromJsonAsync(typeof(IEnumerable<User>)) as IEnumerable<User>;
                }
            }
            return users.ToArray();
        }

        public async Task UpdateUser(User user)
        {
            throw new NotImplementedException();
        }
    }
}
