using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using API.Core.Entity;

namespace API.Data
{
    public class ApiAppContext : DbContext
    {
        public ApiAppContext (DbContextOptions<ApiAppContext> opt) : base(opt)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelbuilder)
        {

        }

        public DbSet<User> Users { get; set; }
    }


}
