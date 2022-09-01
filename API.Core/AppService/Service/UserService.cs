using API.Core.DataService;
using API.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Core.AppService.Service
{
    public class UserService : IUserService
    {
        private IUserRepo _userRepo;

        public UserService(IUserRepo userRepo)
        {
            _userRepo = userRepo;
        }
        public User createUser(User user)
        {
            return _userRepo.createUser(user);
           
        }

        public User deleteUser(int id)
        {
            return _userRepo.deleteUser(id);
        }

        public IEnumerable<User> GetUsers()
        {
            return _userRepo.GetUsers();
        }

        public User ReadyById(int id)
        {
            return _userRepo.ReadyById(id);
        }

        public User UpdateUser(User user)
        {
            return _userRepo.UpdateUser(user);
        }
    }
}
