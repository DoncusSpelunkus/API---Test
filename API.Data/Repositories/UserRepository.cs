using API.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using API.Core.DataService;

namespace API.Data.Repositories
{
    public class UserRepository : IUserRepo
    {
        private ApiAppContext _ctx;
        
        public UserRepository(ApiAppContext ctx)
        {
            _ctx = ctx;
        }

        public IEnumerable<User> GetUsers()
        {
            return _ctx.Users;
        }

        public User createUser(User user)
        {
            var createdUser = _ctx.Add(user).Entity;
            _ctx.SaveChanges();
            return createdUser;
        }

        public User deleteUser(int id)
        {
            User usertoDelete = ReadyById(id);
            _ctx.Attach(usertoDelete).State = EntityState.Deleted;
            _ctx.SaveChanges();
            return usertoDelete;
        }

        public User ReadyById(int id)
        {
            return _ctx.Users.FirstOrDefault(p => p.id == id);
        }

        public User UpdateUser(User user)
        {
            _ctx.Attach(user).State = EntityState.Modified;
            _ctx.SaveChanges();
            return user;
        }
    }
}
