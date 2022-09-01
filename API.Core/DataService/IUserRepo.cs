using API.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Core.DataService
{
    public interface IUserRepo
    {
        IEnumerable<User> GetUsers();

        User createUser(User user);

        User deleteUser(int id);

        User ReadyById(int id);

        User UpdateUser(User user);
    }
}
