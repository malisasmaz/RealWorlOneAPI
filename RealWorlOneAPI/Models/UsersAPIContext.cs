using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RealWorlOneAPI.Models {
    public class UsersAPIContext : DbContext {
        public UsersAPIContext(DbContextOptions options) : base(options) {
        }

        public DbSet<User> Users { get; set; }
    }
}
