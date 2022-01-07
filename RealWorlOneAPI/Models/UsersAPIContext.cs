using Microsoft.EntityFrameworkCore;

namespace RealWorlOneAPI.Models {
    public class UsersAPIContext : DbContext {
        public UsersAPIContext(DbContextOptions options) : base(options) {
        }

        public DbSet<User> Users { get; set; }
    }
}
