using Microsoft.EntityFrameworkCore;

namespace RealWorlOneAPI.Models {
    /// <summary>
    /// Users API context
    /// </summary>
    public class UsersAPIContext : DbContext {
        public UsersAPIContext(DbContextOptions options) : base(options) {
        }

        public DbSet<User> Users { get; set; }
    }
}
