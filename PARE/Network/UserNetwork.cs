using Model;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public async Task UpdateUser(User user)
        {
            throw new NotImplementedException();
        }
    }
}
