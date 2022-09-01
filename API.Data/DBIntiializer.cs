using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using API.Core.Entity;

namespace API.Data
{
    public class DBIntiializer
    {
        public static void giveMeSeed(ApiAppContext ctx)
        {
            ctx.Database.EnsureDeleted();
            ctx.Database.EnsureCreated();

            var user1 = ctx.Users.Add(new User()
            {
                id = 1,
                name = "FuckWobbe",
                age = 22
            }).Entity;
            var user2 = ctx.Users.Add(new User()
            {
                id = 2,
                name = "MyLostBeard",
                age = 2
            }).Entity;
            var user3 = ctx.Users.Add(new User()
            {
                id = 3,
                name = "Lmao",
                age = 2222
            }).Entity;

            ctx.SaveChanges();
        }
    }
}
